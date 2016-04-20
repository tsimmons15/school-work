package application;

import java.util.ArrayList;

import javafx.application.Application;
import javafx.fxml.FXML;
import javafx.geometry.Rectangle2D;
import javafx.stage.*;
import character.Characters;
import DBInterface.*;


public class Controller extends Application {
	private Stage primaryStage;
	private static Page currPage;
	private Characters character;
	
	@Override
	public void start(Stage primaryStage) {
		try {
			this.primaryStage = primaryStage;
			DBInterface.checkDBExists();
			character = new Characters();
			Model.controller = this;
			Rectangle2D screenSize = Screen.getPrimary().getVisualBounds();
			Model.X = screenSize.getMinX();
			Model.Y = screenSize.getMinY();
			Model.height = screenSize.getHeight();
			Model.width = screenSize.getWidth();
			Model.finished = new ArrayList<Integer>();
			for (int i = 0; i < 8; i++) {
				Model.finished.add(0);
			}
			
			nextStage();
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
	public void clearCalled() {
		System.out.println("Clear Called");
	}
	
	public void nextStage() {
		int pageLevel = 0;
		
		if (Controller.currPage != null)
			pageLevel = Controller.currPage.getPageLevel();
		
		Controller.currPage = findNextStage(pageLevel);
		
		this.primaryStage = Controller.currPage.getStage(this.primaryStage);
		if (primaryStage == null) {
			return;
		}
		this.primaryStage.setTitle("Game title");
		this.primaryStage.setX(Model.X);
		this.primaryStage.setY(Model.Y);
		this.primaryStage.setHeight(Model.height);
		this.primaryStage.setWidth(Model.width);
		this.primaryStage.show();
	}
	
	public Page findNextStage(int currStage) {
		Page currPage = null;
		while (currPage == null) {
			switch (currStage) {
			case 0:
				//Start
				currPage = new PageOne();
				break;
			case 1:
				if(Model.attributes.size() > 0)
					currPage = new PageTwo();
				break;
			case 2:
				if (Model.skills.size() > 0)
					currPage = new PageThree();
				break;
			case 3:
				if (Model.spells.size() > 0)
					currPage = new PageFour();
				break;
			case 4:
				if (Model.languages.size() > 0)
					currPage = new PageFive();
				break;
			case 5:
				if (Model.feats.size() > 0)
					currPage = new PageSix();
				break;
			case 6:
				if (Model.items.size() > 0)
					currPage = new PageSeven();
				break;
			case 7:
				currPage = new PageOne();
				
				PageEight page = new PageEight();
				Stage review = page.getStage();
				review.setTitle("Review");
				review.showAndWait();
				break;
			}
			currStage++;
		}
		
		return currPage;
	}
	
	public void prevStage() {
		int pageLevel = Controller.currPage.getPageLevel();
		//Ask user if they wish to leave page
		switch (pageLevel) {
		case 1:
			//Show main menu (yet to be built...)
			break;
		case 2:
			Controller.currPage = new PageOne();
			break;
		case 3:
			Controller.currPage = new PageTwo();
			break;
		case 4:
			Controller.currPage = new PageThree();
			break;
		case 5:
			Controller.currPage = new PageFour();
			break;
		case 6:
			Controller.currPage = new PageFive();
			break;
		case 7:
			Controller.currPage = new PageSix();
			break;
		default:
			System.out.println("Oops...\nRan out of pages.");
			break;
		}
		
		this.primaryStage = Controller.currPage.getStage(this.primaryStage);
		this.primaryStage.setTitle("Game title");
		this.primaryStage.show();
	}
	
	public void startOverStage() {
		int pageLevel = Controller.currPage.getPageLevel();
		//Ask user if they wish to start over
		switch (pageLevel) {
		default:
			Controller.currPage = new PageOne();
			break;
		}
		
		this.primaryStage = Controller.currPage.getStage(this.primaryStage);
		this.primaryStage.setTitle("Game title");
		this.primaryStage.show();
	}

	public static void main(String[] args) {
		launch(args);
	}
	
	public void startOverCalled() {
		startOverStage();
	}
	
	public Characters getCharacter() {
		return this.character;
	}
	
	public static Page getCurrPage() {
		return currPage;
	}
}
