package application;

import java.net.URL;
import java.util.*;

import application.Dialog.Buttons;
import character.*;
import javafx.fxml.*;
import javafx.stage.Stage;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.*;

public class PageFive implements Initializable, Page {
	private Stage primaryStage;

	/* 
	 * @FXML allows for this code to communicate with the FXML pages constructed by Mari
	 * If you wish to capture something created through FXML, it must have an fx:id in the FXML page, 
	 * and must have the same variable name as its fx:id.
	 * Once the holder variable is defined below, work with it in the initialze() method.
	 * Event Handlers are handled half in FXML and half in the controller class:
	 * There needs to be an attribute in the FXML object called "onAction" and it 
	 * needs to point to a method defined in the controlling class.
	 */
	@FXML // fx:id="next"
	private Button next;
	@FXML // fx:id="clear"
	private Button clear;
	@FXML //fx:id="go_back"
	private Button go_back;
	
	@FXML //fx:id="languageList"
	private ListView<Language> languageList;
	@FXML //fx:id="knownLanguages"
	private ListView<Language> knownLanguages;
	
	private int beginLangPoints;
	@FXML
	private Label langPoints;
	
	@Override
	public int getPageLevel() {
		return 5;
	}
	
	

	@Override
	public Stage getStage(Stage primary) {
		try {
			this.primaryStage = primary;
			FXMLLoader loader = new FXMLLoader();
			loader.setLocation(this.getClass().getResource("BackGround.fxml"));
			BorderPane MainMenu = (BorderPane) loader.load();
			Scene scene = new Scene(MainMenu);
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
	
	public Language getLanguageChoice() {
		return languageList.getSelectionModel().getSelectedItem();
	}

	@FXML
	public void clearCalled() {
		languageList.getItems().clear();
		knownLanguages.getItems().clear();
		langPoints.setText(beginLangPoints + "");
		for(Language lang : Model.languages) {
			Race race = Model.controller.getCharacter().getRace();
			if (lang.getLanguage_name().equals("Common"))
				knownLanguages.getItems().add(lang);
			else {
				if (race != null && lang.getLanguage_name().equals(race.getRacialLanguage()))
						knownLanguages.getItems().add(lang);
				else 
					languageList.getItems().add(lang);
			}
		}
	}
	
	@FXML
	public void nextCalled() {
		int result = Buttons.CANCEL;
		if (knownLanguages.getItems().size() >= 1) {
			for (Language lang : knownLanguages.getItems()) {
				Model.controller.getCharacter().addKnownLanguage(lang);
			}
			Model.finished.set(4, 1);
			Model.controller.nextStage();
		} else {
			Dialog diag = new Dialog("You have no spoken languages.\nDo you wish to skip this page and return later?");
			result = diag.showDialog(Dialog.YesNo);
			if (result == Buttons.YES){
				Model.finished.set(4, 0);
				Model.controller.nextStage();
			}
		}
		
	}
	
	@FXML
	public void prevCalled() {
		Model.controller.prevStage();
	}
	
	@FXML
	public void addLanguage() {
		Language lang = languageList.getSelectionModel().getSelectedItem();
		int langpoints = Integer.parseInt(langPoints.getText().trim());
		if (lang != null && langpoints > 0) {
			languageList.getItems().remove(lang);
			knownLanguages.getItems().add(lang);
			sortLists();
			langPoints.setText((langpoints - 1) + "");
		}
	}
	
	public void sortLists() {
		languageList.getItems().sort(new Comparator<Language>() {

			@Override
			public int compare(Language arg0, Language arg1) {
				return arg0.getLanguage_name().compareTo(arg1.getLanguage_name());
			}
			
		});
		knownLanguages.getItems().sort(new Comparator<Language>() {

			@Override
			public int compare(Language arg0, Language arg1) {
				return arg0.getLanguage_name().compareTo(arg1.getLanguage_name());
			}
			
		});
	}
	
	@FXML public void removeLanguage() {
		Language lang = knownLanguages.getSelectionModel().getSelectedItem();
		if (lang != null) {
			knownLanguages.getItems().remove(lang);
			languageList.getItems().add(lang);
			sortLists();
			int langpoints = Integer.parseInt(langPoints.getText().trim());
			langPoints.setText((langpoints + 1) + "");
		}
	}


	@Override
	public void initialize(URL arg0, ResourceBundle arg1) {
		Characters characters = Model.controller.getCharacter();
		if (characters.getAttributeList().containsKey("Intelligence"))
			beginLangPoints = Attributes.getModifier(characters.getAttributeList().getOrDefault("Intelligence", 0));
		clearCalled();
    }
}
