package application;

import javafx.stage.Stage;

public interface Page {
	public int getPageLevel();
	public Stage getStage(Stage primary);
	public void nextCalled();
	public void clearCalled();
	public void prevCalled();
}
