package application;

import java.net.URL;
import java.util.*;

import character.Spells;
import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.BorderPane;
import javafx.stage.Stage;

public class PageFour implements Initializable, Page{
	private Stage primaryStage;
	private TreeMap<Spells, Integer> spellBook;
	
	@FXML // fx:id="next"
	private Button next;
	@FXML // fx:id="clear"
	private Button clear;
	@FXML //fx:id="go_back"
	private Button go_back;
	@FXML //fx:id="addSpell"
	private Button addSpell;
	
	@FXML //fx:id="spellList"
	private ListView<Spells> spellList;
	@FXML //fx:id="spellbook"
	private ListView<Spells> spellbook;
	
	@FXML //fx:id="spellLevel"
	private Label spellLevel;
	@FXML //fx:id="spellDesc"
	private Label spellDesc;
	@FXML //fx:id="spellAOE"
	private Label spellAOE;
	@FXML //fx:id="spellSchool"
	private Label spellSchool;
	@FXML //fx:id="spellComponents"
	private Label spellComponents;
	@FXML //fx:id="spellMaterials"
	private Label spellMaterials;
	@FXML //fx:id="spellRange"
	private Label spellRange;
	
	@Override
	public int getPageLevel() {
		return 4;
	}
		
	@Override
	public Stage getStage(Stage primary) {
		try {
			this.primaryStage = primary;
			FXMLLoader loader = new FXMLLoader();
			loader.setLocation(this.getClass().getResource("Spells.fxml"));
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
	
	@FXML
	public void addSpell() {
		Spells spell = spellList.getSelectionModel().getSelectedItem();
		spellbook.getItems().add(spell);
		spellBook.put(spell, spell.getSpellLevel());
		spellList.getItems().remove(spell);
	}
	
	@FXML
	public void removeSpell() {
		Spells spell = spellbook.getSelectionModel().getSelectedItem();
		spellList.getItems().add(spell);
		spellBook.remove(spell);
		spellbook.getItems().remove(spell);
	}
	
	@FXML
	public void clearCalled() {

	}
	
	@FXML
	public void nextCalled() {
		if (spellbook.getItems().size() > 0) {
			Model.controller.getCharacter().setSpellBook(spellBook);
			Model.finished.set(3, 1);
			Model.controller.nextStage();
		} else {
			int result = -1;
			Dialog dialog = new Dialog("You have not selected any spells.\nWould you like to skip this page to return later?");
			result = dialog.showDialog(Dialog.YesNo);
			
			if (result == Dialog.Buttons.YES) {
				Model.finished.set(3, 0);
				Model.controller.nextStage();
			}
		}
	}
	
	@FXML
	public void prevCalled() {
		Model.controller.prevStage();
	}

	public void initialize(URL arg0, ResourceBundle arg1) {		
		spellBook = new TreeMap<Spells, Integer>();
		
		spellList.getSelectionModel().selectedItemProperty()
		.addListener(new ChangeListener<Spells>() {
			@Override
			public void changed(
					ObservableValue<? extends Spells> arg0,
					Spells arg1, Spells arg2) {
				// arg1 is previous class (if any...)
				// arg2 is current class
				selectedSpellChanged(arg2);
			}
		});
		for (Spells spell : Model.spells) {
			spellList.getItems().add(spell);
		}
		toggleDetailVisibility(false);
	}
	
	private void toggleDetailVisibility(boolean visibility) {
		spellLevel.visibleProperty().set(visibility);
		spellRange.visibleProperty().set(visibility);
		spellAOE.visibleProperty().set(visibility);
		spellDesc.visibleProperty().set(visibility);
		spellSchool.visibleProperty().set(visibility);
		spellComponents.visibleProperty().set(visibility);
		spellMaterials.visibleProperty().set(visibility);
	}
	
	private void selectedSpellChanged(Spells spell) {
		if (spell == null) {
			toggleDetailVisibility(false);
		} else {
			toggleDetailVisibility(true);
			spellLevel.setText(spell.getSpellLevel()+"");
			spellRange.setText(spell.getSpellRange()+"");
			spellAOE.setText(spell.getSpellAOE());
			spellDesc.setText(spell.getSpellDescription());
			spellSchool.setText("Universal");
			String prereqs = spell.getSpellPrerequisites();
			String[] mats = prereqs.split(" -- ");
			if (mats[0].length() > 0)
				spellComponents.setText(mats[0]);
			if (mats[1].length() > 0) {
				spellMaterials.setText(mats[1]);
			}
		}
	}
}
