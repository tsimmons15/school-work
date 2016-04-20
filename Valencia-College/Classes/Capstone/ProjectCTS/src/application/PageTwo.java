
package application;

import java.net.URL;
import java.util.*;

import character.*;
import javafx.event.*;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.geometry.Insets;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.image.*;
import javafx.scene.layout.*;
import javafx.stage.Stage;

public class PageTwo implements Initializable, Page{
	private Stage primaryStage;
	private ArrayList<Integer> attrValues;
	private ArrayList<Integer> savedValues;
	private boolean saved;
	
	@FXML
	private Button next;	
	@FXML	
	private Button clear;
	@FXML
	private Button go_back;
	
	@FXML
	private Button saveRoll;
	@FXML
	private Button forgetRoll;
	@FXML
	private Button rollDice;
	
	@FXML //fx:id="attributePane"
	private VBox attributePane;
	
	@FXML
	private HBox buttonBox;
	
	@Override
	public int getPageLevel() {
		return 2;
	}
	
	@Override
	public Stage getStage(Stage primary) {
		try {
			// Load CharacterName.
			this.primaryStage = primary;
			FXMLLoader loader = new FXMLLoader();
			loader.setLocation(this.getClass().getResource("/application/Attributes.fxml"));
			BorderPane Attributes = (BorderPane) loader.load();
			Scene scene = new Scene(Attributes);
			scene.getStylesheets().add(
					getClass().getResource("application.css").toExternalForm());
			this.primaryStage.setScene(scene);

			return primaryStage;
//			HBox partition = new HBox(15);
//			partition.setPrefWidth(800);
//			Button rollDice = new Button("Roll Dice");
//			Button forgetRoll = new Button("Forget");
//			Button saveRoll = new Button("Save");
//			partition.getChildren().add(rollDice);
//			partition.getChildren().add(saveRoll);
//			partition.getChildren().add(forgetRoll);
//			buttons.addPartition(partition);

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
		TreeMap<String, Integer> charAttr = new TreeMap<String, Integer>();
		ArrayList<Integer> used;
		ArrayList<Attributes> attr = Model.getAttributes();
		int response = 0;
		
		if (saved) {
			Dialog dialog = new Dialog("You have saved values.\nWould you like to use them?");
			response = dialog.showDialog(Dialog.YesNoCancel);
		} 
		if (response != Dialog.Buttons.CANCEL) {
			//If response is YES use saved Values instead
			if (response == Dialog.Buttons.YES) {
				used = savedValues;
			} else {
				used = attrValues;
			}
			for(int i = 0; i < used.size(); i++) {
				Race race = Model.controller.getCharacter().getRace();
				int value = used.get(i);
				String attrName = attr.get(i).getAttribute_name();
				if (race != null) {
					value += race.getRace_bonuses().getOrDefault(attrName, 0);
				}
				charAttr.put(attrName, value);
			}
			
			Model.controller.getCharacter().setAttributeList(charAttr);
			Model.finished.set(1, 1);
			Model.controller.nextStage();
		}
	}
	
	@FXML
	public void prevCalled() {
		Model.controller.prevStage();
	}

	@FXML
	public void newDiceRoll() {
		int size = attrValues.size();
		attrValues.clear();
		for (int i = 0; i < size; i++) {
			HBox pane = ((HBox)attributePane.getChildren().get(i));
			int total = 0, min = 7;
			for (int j = 0; j < 4; j++) {
				int dice = (int)(Math.random() * 100 % 6 + 1);
				total += dice;
				min = Math.min(dice, min);
			}
			total -= min;
			attrValues.add(total);
			((Label)pane.getChildren().get(1)).setText(padNumber(total, 3));
			((Label)pane.getChildren().get(2)).setText("(" + padNumber(Attributes.getModifier(total), 2) + ")");
		}
	}
	
	@FXML
	public void saveCurrRoll() {
		saved = true;
		int i = 0;
		for (Node pane : attributePane.getChildren()) {
			//2nd is attrValue
			//6th is savedValue
			int attrValue = Integer.parseInt(((Label)((HBox)pane).getChildren().get(1)).getText().trim());
			//Get the attrValue value
			((Label)((HBox)pane).getChildren().get(5)).setText(padNumber(attrValue, 3));
			((Label)((HBox)pane).getChildren().get(6)).setText("(" +padNumber(Attributes.getModifier(attrValue), 2) + ")");
			savedValues.set(i, attrValue);
			i++;
		}
	}
	
	@FXML
	public void forgetSavedRoll() {
		saved = false;
		for (Node pane : attributePane.getChildren()) {
			//2nd is attrValue
			//6th is savedValue
			((Label)((HBox)pane).getChildren().get(5)).setText("0");
			((Label)((HBox)pane).getChildren().get(6)).setText("(0  )");	
		}
	}
	
	private void firstRoll(int size) {
		for (int i = 0; i < size; i++) {
			int total = 0, min = 7;
			for (int j = 0; j < 4; j++) {
				int dice = (int)(Math.random() * 100 % 6 + 1);
				total += dice;
				min = Math.min(dice, min);
			}
			total -= min;
			attrValues.add(total);
		}
	}
	
	private String padNumber(int value, int spaces) {
		String padded = "";
		int digits = 0;
		padded += value;
		if (value < 10) 
			spaces += 2;
		digits = padded.length();
		
		if (digits < spaces) {
			for (; digits <= spaces; digits ++) {
				padded += " ";
			}
		}
		return padded;
	}
	
	public void initialize(URL arg0, ResourceBundle arg1) {
		ArrayList<Attributes> attrList = Model.getAttributes();
		saved = false;
		attrValues = new ArrayList<Integer>();
		savedValues = new ArrayList<Integer>();
		firstRoll(attrList.size());
		for (int i = 0; i < attrList.size(); i++) {
			savedValues.add(0);
		}
		for(int i = 0; i < attrList.size(); i++) {
			final int round = i;
			HBox attrPane = new HBox();
			Label attrLbl = new Label(attrList.get(i).getAttribute_name());
			attrLbl.setMinWidth(300);
			attrLbl.setMaxWidth(Double.MAX_VALUE);
			attrLbl.setStyle("-fx-font-size: 15pt;-fx-font-weight:bold;");
			attrPane.getChildren().add(attrLbl);
			final Label attrValue = new Label(padNumber(attrValues.get(i), 2));
			attrValue.setMinWidth(40);
			attrValue.setMaxWidth(Double.MAX_VALUE);
			attrValue.setStyle("-fx-font-size: 15pt;");
			attrPane.getChildren().add(attrValue);
			final Label attrModifier = new Label("(" + padNumber(Attributes.getModifier(attrValues.get(i)), 2) + ")");
			attrModifier.setMinWidth(50);
			attrModifier.setMaxWidth(Double.MAX_VALUE);
			attrModifier.setStyle("-fx-font-size: 15pt;");
			attrPane.getChildren().add(attrModifier);
			
			Image arrow = new Image(getClass().getResourceAsStream("right_arrow.png"));
			Button saveButton = new Button();
			saveButton.setGraphic(new ImageView(arrow));
			attrPane.getChildren().add(saveButton);
			HBox.setMargin(saveButton, new Insets(0, 60, 0, 60));
			
			Label savedLbl = new Label(attrList.get(i).getAttribute_name());
			savedLbl.setMinWidth(300);
			savedLbl.setMaxWidth(Double.MAX_VALUE);
			savedLbl.setStyle("-fx-font-size: 15pt;-fx-font-weight:bold;");
			attrPane.getChildren().add(savedLbl);
			final Label savedValue = new Label(savedValues.get(i).toString());
			savedValue.setMinWidth(40);
			savedValue.setMaxWidth(Double.MAX_VALUE);
			savedValue.setStyle("-fx-font-size: 15pt;");
			attrPane.getChildren().add(savedValue);
			final Label savedModifier = new Label();
			savedModifier.setMinWidth(50);
			savedModifier.setMaxWidth(Double.MAX_VALUE);
			savedModifier.setStyle("-fx-font-size: 15pt;");
			attrPane.getChildren().add(savedModifier);
			saveButton.setOnAction(new EventHandler<ActionEvent>() {
				@Override
				public void handle(ActionEvent arg0) {
					int attr = Integer.parseInt(attrValue.getText().trim());
					savedValue.setText(padNumber(attr, 2));
					savedModifier.setText("(" + padNumber(Attributes.getModifier(attr), 2) + ")");
					savedValues.set(round, Integer.parseInt(savedValue.getText().trim()));
				}
			});
			
			attributePane.getChildren().add(attrPane);
			attributePane.fillWidthProperty().set(true);
		}
	}
}

