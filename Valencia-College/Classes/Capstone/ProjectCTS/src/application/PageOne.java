package application;

import java.net.URL;
import java.util.*;

import application.Dialog.Buttons;
import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.fxml.*;
import javafx.scene.*;
import javafx.scene.layout.*;
import javafx.scene.control.*;
import javafx.stage.Stage;
import character.*;
import DBInterface.*;

public class PageOne implements Initializable, Page {

	private Characters viewCharacter;
	private Stage primaryStage;

	/*
	 * @FXML allows for this code to communicate with the FXML pages constructed
	 * by Mari If you wish to capture something created through FXML, it must
	 * have an fx:id in the FXML page, and must have the same variable name as
	 * its fx:id. Once the holder variable is defined below, work with it in the
	 * initialze() method.
	 */

	@FXML
	private Button next;
	@FXML
	private Button clear;
	@FXML
	private Button go_back;
	
	@FXML
	private HBox buttonBox;
	@FXML
	// fx:id="tabs"
	private TabPane tabs;

	@FXML
	// fx:id="charName"
	private TextField charName;
	@FXML
	// fx:id="filterValue"
	private TextField filterValue;
	@FXML
	// fx:id="charAlignment"
	private TextField charAlignment;
	@FXML
	// fx:id="charLevel"
	private TextField charLevel;
	@FXML
	// fx:id="charSize"
	private TextField charSize;
	@FXML
	// fx:id="charGender"
	private TextField charGender;
	@FXML
	// fx:id="charWeight"
	private TextField charWeight;
	@FXML
	// fx:id="charHeightFoot"
	private TextField charHeightFoot;
	@FXML
	// fx:id="charHeightInch"
	private TextField charHeightInch;
	@FXML
	// fx:id="charAge"
	private TextField charAge;
	@FXML
	// fx:id="hairColor"
	private TextField hairColor;
	@FXML
	// fx:id="skinType"
	private TextField skinType;

	@FXML
	// fx:id="raceDesc"
	private TextArea raceDesc;
	@FXML
	// fx:id="classDesc"
	private TextArea classDesc;
	@FXML
	// fx:id="backgroundDesc"
	private TextArea backgroundDesc;
	@FXML
	// fx:id="deityDesc"
	private TextArea deityDesc;

	@FXML
	// fx:id="classList"
	private ListView<Classes> classList;
	@FXML
	// fx:id="raceList"
	private ListView<Race> raceList;
	@FXML
	// fx:id="characterList"
	private ListView<Characters> characterList;
	@FXML
	// fx:id="backgroundList"
	private ListView<Nationality> backgroundList;
	@FXML
	// fx:id="deityList"
	private ListView<Deity> deityList;

	@FXML
	// fx:id="filterList"
	private ComboBox<String> filterList;

	@FXML
	// fx:id="nameDetail"
	private Label nameDetail;
	@FXML
	// fx:id="raceDetail"
	private Label raceDetail;
	@FXML
	// fx:id="classDetail"
	private Label classDetail;
	@FXML
	// fx:id="timeUpdated"
	private Label timeUpdated;
	@FXML
	// fx:id="follower"
	private Label follower;

	@Override
	public Stage getStage(Stage primary) {
		try {

			this.primaryStage = primary;
			FXMLLoader loader = new FXMLLoader();
			loader.setLocation(Page.class.getResource("/application/MainMenu.fxml"));
			BorderPane MainMenu = (BorderPane) loader.load();
			Scene scene = new Scene(MainMenu);
			scene.getStylesheets().add(
					getClass().getResource("application.css").toExternalForm());
			this.primaryStage.setScene(scene);

			return primaryStage;
		} catch (Exception e) {
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

	@Override
	public int getPageLevel() {
		return 1;
	}

	public String getCharName() {
		return charName.getText();
	}

	public Classes getClassChoice() {
		return classList.getSelectionModel().getSelectedItem();
	}

	public Race getRaceChoice() {
		return raceList.getSelectionModel().getSelectedItem();
	}

	public void clearStage() {
		System.out.println("Clear Called");
	}

	private void nextStage() {
		try {
			int skipPage = 0;
			int done = 0;
			if (!allFieldsFilled()) {
				Dialog askSkip = new Dialog(
						"There are fields left blank.\nDo you wish to skip this section, to return later?");
				skipPage = askSkip.showDialog(Dialog.YesNo);
			} else {
				done = 1;
			}
			if (skipPage == Buttons.YES) {
				done = 0;
			}
			Characters character = Model.controller.getCharacter();
			if (charName.getText().length() > 0) {
				String name = charName.getText();
				character.setName(name);
			}
			if (hairColor.getText().length() > 0) {
				String charHair = hairColor.getText();
				character.setHairColor(charHair);	
			}
			if (skinType.getText().length() > 0) {
				String skin = skinType.getText();
				character.setSkin(skin);
			}
			if (!classList.getSelectionModel().isEmpty()) {
				Classes classes = classList.getSelectionModel()
								.getSelectedItem();
				character.addLevel(classes, 1);
				/*int charGold = 0;
				Random rand = new Random();
				for (int i = 0; i < classes.getGoldDice(); i++) {
					charGold += rand.nextInt(6) + 1;
				}
				charGold *= 10;
				character.getInventory().addGold(charGold);
				*/
				character.getInventory().setPurse_Gold(100);
				character.getInventory().normalizePurse();
				switch(character.getClasses().firstKey().getClass_name()) {
				case "Barbarian": 
					character.setHealth(12);
					break;
				case "Bard": 
					character.setHealth(6);
					break;
				case "Cleric": 
					character.setHealth(8);
					break;
				case "Druid": 
					character.setHealth(8);
					break;
				case "Fighter": 
					character.setHealth(10);
					break;
				case "Monk": 
					character.setHealth(8);
					break;
				case "Paladin": 
					character.setHealth(10);
					break;
				case "Ranger": 
					character.setHealth(8);
					break;
				case "Rogue": 
					character.setHealth(6);
					break;
				case "Sorcerer": 
					character.setHealth(4);
					break;
				case "Wizard": 
					character.setHealth(4);
					break;
				default: 
					character.setHealth(6);
					break;
				}
			}
			if (!raceList.getSelectionModel().isEmpty()) {
				Race race = raceList.getSelectionModel().getSelectedItem();
				character.setRace(race);
				character.setSize(race.getRace_defaultSize());
				character.setSpeed(race.getRace_speed());
			}
			if (!deityList.getSelectionModel().isEmpty()) {
				Deity deity = deityList.getSelectionModel().getSelectedItem();
				character.setReligion(deity);
			}
			if (charGender.getText().length() > 0) {
				char gender = charGender.getText().charAt(0);
				character.setGender(gender);
			}
			if (charAge.getText().length() > 0) {
				int age = Integer.parseInt(charAge.getText()); 
				character.setAge(age);
			}
			int[] height = new int[2];
			if (charHeightFoot.getText().length() > 0) {
				height[0] = Integer.parseInt(charHeightFoot.getText());
			} else {
				height[0] = 5;
			}
			if (charHeightInch.getText().length() > 0) {
				height[1] = Integer.parseInt(charHeightInch.getText());
			} else {
				height[1] = 0;
			}
			character.setHeight(height);
			if (charWeight.getText().length() > 0) {
				int weight = Integer.parseInt(charWeight.getText());
				character.setWeight(weight); 
			}
			if (charAlignment.getText().length() == 2) {
				char[] alignment = new char[2];
				alignment[0] = charAlignment.getText().split("")[0].charAt(0);
				alignment[1] = charAlignment.getText().split("")[1].charAt(0);
				character.setAlignment(alignment);
			}
			character.setExperience(1);
			
			Model.finished.set(0, done);
			Model.controller.nextStage();
		} catch (Exception e) {
			String error = e.getMessage() + "\n";
			StackTraceElement[] ste = e.getStackTrace();
			for (StackTraceElement element : ste) {
				error += "\t" + element.toString() + "\n";
			}
			Dialog dialog = new Dialog(error);
			dialog.showDialog(Dialog.Yes);
		}
	}
	
	@FXML
	public void nextCalled() {
		switch (next.getText()) {
		case "Next":
			nextStage();
			break;
		case "View":
			viewCharacter();
			break;
		}
	}
	
	@FXML
	public void clearCalled() {
		switch (next.getText()) {
		case "Clear":
			clearStage();
			break;
		case "Delete":
			deleteCharacter();
			break;
		}
	}

	@FXML
	public void prevCalled() {
		switch (go_back.getText()) {
		case "Go Back":
			// Where exactly are you trying to go, Dave?
			break;
		case "Edit":
			openEdit();
			break;
		}
	}

	private boolean allFieldsFilled() {
		boolean finished = true;
		try {
			if (charName.getText() == "")
				finished = false;
			if (hairColor.getText() == null)
				finished = false;
			if (skinType.getText() == null)
				finished = false;
			if (classList.getSelectionModel().getSelectedItem() == null
					&& !classList.disabledProperty().get())
				finished = false;
			if (raceList.getSelectionModel().getSelectedItem() == null
					&& !raceList.disabledProperty().get())
				finished = false;
			char character = Character.toLowerCase(charGender.getText().charAt(
					0));
			if (character != 'm' && character != 'f')
				finished = false;
			if (Integer.parseInt(charAge.getText()) <= 0)
				finished = false;
			if (Integer.parseInt(charHeightFoot.getText()) <= 0)
				finished = false;
			if (Integer.parseInt(charHeightInch.getText()) <= 0)
				finished = false;
			if (Integer.parseInt(charWeight.getText()) <= 0)
				finished = false;
		} catch (Exception e) {
			String error = e.getMessage() + "\n";
			StackTraceElement[] ste = e.getStackTrace();
			for (StackTraceElement element : ste) {
				error += "\t" + element.toString() + "\n";
			}
			Dialog dialog = new Dialog(error);
			dialog.showDialog(Dialog.Yes);
			finished = false;
		}
		return finished;
	}

	public void openEdit() {
		if (viewCharacter != null)
			System.out.println("Edit " + viewCharacter.getName());
		else
			System.out.println("No char selected");
	}

	public void viewCharacter() {
		if (viewCharacter != null)
			System.out.println("View " + viewCharacter.getName());
		else
			System.out.println("No char selected");
	}

	public void deleteCharacter() {
		if (viewCharacter != null)
			System.out.println("Delete " + viewCharacter.getName());
		else
			System.out.println("No char selected");
	}

	@Override
	public void initialize(URL arg0, ResourceBundle arg1) {
		tabs.getSelectionModel().selectedIndexProperty()
				.addListener(new ChangeListener<Number>() {
					@Override
					public void changed(ObservableValue<? extends Number> arg0,
							Number arg1, Number arg2) {
						// Next = 2
						// Clear = 1
						// Go_Back = 0
						switch (arg2.intValue()) {
						case 0:
							if (!buttonBox.isVisible())
								buttonBox.visibleProperty().set(true);
							next.setText("Next");
							clear.setText("Clear");
							go_back.setText("Go Back");
							break;
						case 1:
							if (!buttonBox.isVisible())
								buttonBox.visibleProperty().set(true);
							next.setText("View");
							clear.setText("Delete");
							go_back.setText("Edit");
							break;
						case 2:
							buttonBox.visibleProperty().set(false);
							break;
						}
					}
				});

		raceDesc.editableProperty().set(false);
		raceDesc.setText("Please select a race from the list...");
		classDesc.editableProperty().set(false);
		classDesc.setText("Please select a class from the list...");
		backgroundDesc.editableProperty().set(false);
		backgroundDesc.setText("Please select a nationality from the list...");
		deityDesc.editableProperty().set(false);
		deityDesc.setText("Please select a deity from the list...");

		ArrayList<Nationality> nationalities = Model.nationality;
		ArrayList<Classes> classes = Model.classes;
		ArrayList<Race> races = Model.races;
		ArrayList<Deity> deities = Model.deity;
		if (classes != null) {
			classList.getItems().addAll(classes);
			classList.getSelectionModel().selectedItemProperty()
					.addListener(new ChangeListener<Classes>() {
						@Override
						public void changed(
								ObservableValue<? extends Classes> arg0,
								Classes arg1, Classes arg2) {
							// arg1 is previous class (if any...)
							// arg2 is current class
							classDesc.setText(arg2.getClass_description());
						}
					});
		} else {
			classList.disableProperty().set(true);
			classDesc.setText("No Classes available...");
		}
		if (races != null) {
			raceList.getItems().addAll(races);
			raceList.getSelectionModel().selectedItemProperty()
					.addListener(new ChangeListener<Race>() {
						@Override
						public void changed(
								ObservableValue<? extends Race> arg0,
								Race arg1, Race arg2) {
							raceDesc.setText(arg2.getRace_description());
						}
					});
		} else {
			raceList.disableProperty().set(true);
			raceDesc.setText("No Races available...");
		}
		if (nationalities != null) {
			backgroundList.getItems().addAll(nationalities);
			backgroundList.getSelectionModel().selectedItemProperty()
					.addListener(new ChangeListener<Nationality>() {
						@Override
						public void changed(
								ObservableValue<? extends Nationality> arg0,
								Nationality arg1, Nationality arg2) {
							// arg1 is previous class (if any...)
							// arg2 is current class
							backgroundDesc.setText(arg2.getNationality_text());
						}
					});
		} else {
			backgroundList.disableProperty().set(true);
			backgroundDesc.setText("No Nationalities available...");
		}
		if (deities != null) {
			deityList.getItems().addAll(deities);
			deityList.getSelectionModel().selectedItemProperty()
					.addListener(new ChangeListener<Deity>() {
						@Override
						public void changed(
								ObservableValue<? extends Deity> arg0,
								Deity arg1, Deity arg2) {
							String formatText = "Name: " + arg2.getDeity_name()
									+ "\nAlignment:"
									+ arg2.getDeity_alignment()[0]
									+ arg2.getDeity_alignment()[1]
									+ "\nDomains: ";
							for (int i = 0; i < arg2.getDeity_domains().size(); i++) {
								formatText += arg2.getDeity_domains().get(i)
										.getDomain_name();
								if (i < arg2.getDeity_domains().size() - 1) {
									formatText += ", ";
								}
							}
							deityDesc.setText(formatText);
						}
					});
		} else {
			deityList.disableProperty().set(true);
			deityDesc.setText("No Deities available...");
		}

		// Edit/View Character Initialize
		ArrayList<Characters> oldCharacters = DBInterface.getCharacterList();
		if (oldCharacters != null && oldCharacters.size() > 0) {
			characterList.getItems().addAll(oldCharacters);
			characterList.getSelectionModel().selectedItemProperty()
					.addListener(new ChangeListener<Characters>() {
						@Override
						public void changed(
								ObservableValue<? extends Characters> arg0,
								Characters arg1, Characters arg2) {
							viewCharacter = arg2;
							nameDetail.setText(arg2.getName());
							nameDetail.visibleProperty().set(true);
							timeUpdated.setText(new Date(arg2.getTimeUpdated())
									.toString());
							timeUpdated.visibleProperty().set(true);
							raceDetail.setText(arg2.getRace().getRace_name());
							raceDetail.visibleProperty().set(true);
							classDetail.setText(arg2.getClasses().firstKey()
									.getClass_name());
							classDetail.visibleProperty().set(true);
							String followerDetail = DBInterface
									.checkFollower(arg2.getPerson_ID());
							follower.setText(followerDetail);
							follower.visibleProperty().set(true);
						}
					});
		}
	}
}
