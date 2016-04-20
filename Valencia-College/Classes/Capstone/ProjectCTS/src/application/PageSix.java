package application;

import java.net.URL;
import java.util.Comparator;
import java.util.ResourceBundle;

import character.*;
import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.BorderPane;
import javafx.stage.Stage;

public class PageSix  implements Initializable, Page{
	private Stage primaryStage;
	@FXML // fx:id="next"
	private Button next;
	@FXML // fx:id="clear"
	private Button clear;
	@FXML //fx:id="go_back"
	private Button go_back;
	
	@FXML //fx:id="featList"
	private ListView<Feat> featList;
	@FXML //fx:id="gainedFeats"
	private ListView<Feat> gainedFeats;
	
	@FXML //fx:id="featDesc"
	private Label featDesc;
	
	@FXML //fx:id="selectFeat"
	private Button selectFeat;
	@FXML //fx:id="removeFeat"
	private Button removeFeat;
	
	private int featpoints;
	
	@FXML
	private Label featPoints;
	
	@Override
	public int getPageLevel() {
		return 6;
	}
		
	@Override
	public Stage getStage(Stage primary) {
		try {
			// Load Background page.
			this.primaryStage = primary;
			FXMLLoader loader = new FXMLLoader();
			loader.setLocation(this.getClass().getResource("Feats.fxml"));
			BorderPane Feats = (BorderPane) loader.load();
			Scene scene = new Scene(Feats);
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
		gainedFeats.getItems().clear();
		featList.getItems().clear();
		featPoints.setText(featpoints + "");
		for (Feat feat : Model.feats) {
			featList.getItems().add(feat);
		}
		featList.getSelectionModel().select(0);
	}
		
	@FXML
	public void nextCalled() {
		if (gainedFeats.getItems().size() >= 1) {
			for (Feat feat : gainedFeats.getItems()) {
				Model.controller.getCharacter().addFeat(feat);
			}
			Model.finished.set(5, 1);
			Model.controller.nextStage();
		} else {
			Dialog diag = new Dialog();
			int result = diag.showDialog("You have no selected Feats.\nDo you wish to skip this page, to return later?", Dialog.YesNo);
			if (result == Dialog.Buttons.YES) {
				Model.finished.set(5, 0);
				Model.controller.nextStage();
			}
		}
	}
		
	@FXML
	public void prevCalled() {
		Model.controller.prevStage();
	}
	
	@FXML
	public void featSelected() {
		Feat feat = featList.getSelectionModel().getSelectedItem();
		int featpoints = Integer.parseInt(featPoints.getText().trim());
		if (feat != null && featpoints > 0) {
			featList.getItems().remove(feat);
			gainedFeats.getItems().add(feat);
			sortLists();
			featPoints.setText((featpoints - 1) + "");
		}
	}	
	
	@FXML
	public void featRemoved() {
		Feat feat = gainedFeats.getSelectionModel().getSelectedItem();
		if (feat != null) {
			gainedFeats.getItems().remove(feat);
			featList.getItems().add(feat);
			sortLists();
			int featpoints = Integer.parseInt(featPoints.getText().trim());
			featPoints.setText((featpoints + 1) + "");
		}
	}
	
	public void sortLists() {
		featList.getItems().sort(new Comparator<Feat>() {

			@Override
			public int compare(Feat arg0, Feat arg1) {
				return arg0.getFeat_name().compareTo(arg1.getFeat_name());
			}
			
		});
		gainedFeats.getItems().sort(new Comparator<Feat>() {

			@Override
			public int compare(Feat arg0, Feat arg1) {
				return arg0.getFeat_name().compareTo(arg1.getFeat_name());
			}
			
		});
	}

	private void selectedFeatChanged(Feat feat) {
		if (feat != null) 
			featDesc.setText("Name: " + feat.getFeat_name() + "\n" + feat.getFeat_description() + "\nPrerequisites: " + feat.getFeat_prerequisite());
	}

	public void initialize(URL arg0, ResourceBundle arg1) {		
		this.featpoints = 1;
		Race race = Model.controller.getCharacter().getRace();
		if (race != null && Model.controller.getCharacter().getClasses().size() > 0) {
			Classes classes = Model.controller.getCharacter().getClasses().firstEntry().getKey();
			if (race.getRace_name().equals("Human"))
				this.featpoints++;
			if (classes.getClass_name().equals("Fighter"))
				this.featpoints++;
		}
		featList.getSelectionModel().selectedItemProperty()
		.addListener(new ChangeListener<Feat>() {
			@Override
			public void changed(
					ObservableValue<? extends Feat> arg0,
					Feat arg1, Feat arg2) {
				// arg1 is previous class (if any...)
				// arg2 is current class
				selectedFeatChanged(arg2);
			}
		});
		
		clearCalled();
	}

}
