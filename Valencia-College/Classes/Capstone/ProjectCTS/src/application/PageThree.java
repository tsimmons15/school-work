package application;

import java.net.URL;
import java.util.*;

import character.Attributes;
import character.Characters;
import character.Skills;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.*;
import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.*;
import javafx.stage.Stage;

public class PageThree implements Initializable, Page {
	private Stage primaryStage;
	@FXML
	private HBox masterPane;
	TreeMap<Skills, Integer> skillList = new TreeMap<Skills, Integer>();

	
	@FXML // fx:id="next"
	private Button next;
	@FXML // fx:id="clear"
	private Button clear;
	@FXML //fx:id="go_back"
	private Button go_back;

	@FXML
	private Label skillPoints;
	
	@Override
	public int getPageLevel() {
		return 3;
	}
		
	@Override
	public Stage getStage(Stage primary) {
		try {
			// Load CharacterName.
			this.primaryStage = primary;
			FXMLLoader loader = new FXMLLoader();
			loader.setLocation(this.getClass().getResource("Skills.fxml"));
			BorderPane Skills = (BorderPane) loader.load();
			Scene scene = new Scene(Skills);
			scene.getStylesheets().add(
					getClass().getResource("application.css").toExternalForm());
			this.primaryStage.setScene(scene);

			return primaryStage;
		}catch (Exception e) {
			String error = e.getMessage() + "\n";
			StackTraceElement[] ste = e.getStackTrace();
			for (StackTraceElement element : ste) {
				error += "\t" + element.toString() + "\n";
			}
			Dialog dialog = new Dialog(error);
			dialog.showDialog(Dialog.Yes);
			return null;
		}
	}

	@FXML
	public void clearCalled() {

	}
		
	@FXML
	public void nextCalled() {
		//1 is skill name
		//2 is skill Attribute
		//3 is btnDecrease
		//4 is txt
		//5 is btnIncrease
		int i = 0;
		int j = 0;
		int complete = 0;
		for (Skills skill : skillList.keySet()) {
			try {
				
				HBox pane = (HBox)((VBox)masterPane.getChildren().get(j)).getChildren().get(i);
				int value = Integer.parseInt(((TextField)pane.getChildren().get(3)).getText());
				skillList.put(skill, value);
				if (j == 2) {
					j = 0;
					i++;
				} else {
					j ++;
				}
			} catch (Exception e) {
				Dialog dialog = new Dialog(e.getMessage() + "\n");
				dialog.showDialog(Dialog.Yes);
			}
		}
		for (Integer integer : skillList.values())
			if (integer > complete)
				complete = integer;
		if (complete >= 1) {
			Model.controller.getCharacter().setSkillList(skillList);
			Model.finished.set(2, 1);
			Model.controller.nextStage();
		} else {
			int response = -1;
			Dialog dialog = new Dialog("You have not selected any skill to train.\nDo you wish to skip this page to return later?");
			response = dialog.showDialog(Dialog.YesNo);
			if (response == Dialog.Buttons.YES) {
				Model.finished.set(2, 0);
				Model.controller.nextStage();
			}
		}
	}
		
	@FXML
	public void prevCalled() {
		Model.controller.prevStage();
	}

	public void initialize(URL arg0, ResourceBundle arg1) {
		VBox leftPane = new VBox(5);
		VBox midPane = new VBox(5);
		VBox rightPane = new VBox(5);
		int skillpoints = 0;
		if (Model.controller.getCharacter().getClasses().size() > 0) {
			Characters character = Model.controller.getCharacter();
			skillpoints  = character.getClasses().firstKey().getSkillPerLevel();
			skillpoints += Attributes.getModifier(character.getAttributeList().getOrDefault(
					character.getClasses().firstKey().getSkillAttribute().getAttribute_name(), 0));
			skillpoints *= character.getClasses().firstKey().getSkillMultiplier();
		}
		skillPoints.setText(skillpoints + "");
		int i = 0;
		// Load Background page.
		ArrayList<Skills> skills = Model.getSkills();
		for (Skills skill : skills) {
			i++;
			skillList.put(skill, 0);
			HBox pane = new HBox();
			Label lblSkillName = new Label(skill.getSkill_name());
			lblSkillName.setMinWidth(110);
			pane.getChildren().add(lblSkillName);
			Label lblAttribute = new Label("(" + skill.getSkill_attribute() + ")");
			lblAttribute.setMinWidth(75);
			pane.getChildren().add(lblAttribute);
			Button btnDecrease =  new Button("-");
			btnDecrease.setMaxHeight(10);
			pane.getChildren().add(btnDecrease);
			TextField skillRanks = new TextField("0");
			skillRanks.setMaxWidth(50);
			HBox.setMargin(skillRanks, new Insets(0, 10, 0, 10));
			pane.getChildren().add(skillRanks);
			Button btnIncrease = new Button("+");
			btnIncrease.setMaxHeight(10);
			btnDecrease.setOnAction(new EventHandler<ActionEvent>() {
				@Override
				public void handle(ActionEvent arg0) {
					int skillValue = Integer.parseInt(skillRanks.getText());
					if (skillValue >= 1) {
						if (isClassSkill(skill)) {
							skillRanks.setText(skillValue - 1 + "");
							int skillPointsAvailable = Integer.parseInt(skillPoints.getText());
							skillPoints.setText(skillPointsAvailable + 1 + "");
						} else {
							skillRanks.setText((skillValue - 1) + "");
							int skillPointsAvailable = Integer.parseInt(skillPoints.getText());
							skillPoints.setText(skillPointsAvailable + 2 + "");
						}
						
					}
				}
			});
			btnIncrease.setOnAction(new EventHandler<ActionEvent>() {
				@Override
				public void handle(ActionEvent arg0) {
				    int skillpoints = Integer.parseInt(skillPoints.getText().trim());
				    if (skillpoints >= 1) {
						int skillValue = Integer.parseInt(skillRanks.getText());
						int charLevel = Model.controller.getCharacter().getClasses().firstEntry().getValue();
						if (isClassSkill(skill) && (skillValue + 1) <= charLevel) {
							skillRanks.setText(skillValue + 1 + "");
							skillPoints.setText(--skillpoints + "");
						} else if ((skillpoints - 2) >= 0 && (skillValue + 1) <= charLevel) {
							skillRanks.setText((skillValue + 1) + "");
							skillpoints -= 2;
							skillPoints.setText(skillpoints + "");
						}
				    }
				}
			});
			pane.getChildren().add(btnIncrease);
			if ((i % 3) == 0) {
				rightPane.getChildren().add(pane);
			} else if ((i % 3) == 1){
				leftPane.getChildren().add(pane);
			} else {
				midPane.getChildren().add(pane);
			}
		}
		masterPane.getChildren().add(leftPane);
		masterPane.getChildren().add(midPane);
		masterPane.getChildren().add(rightPane);
	}

	protected boolean isClassSkill(Skills skill) {
		boolean ret = false;
		if (Model.controller.getCharacter().getClasses().firstKey().getClass_skills().contains(skill))
			ret = true;
		return ret;
	}

}
