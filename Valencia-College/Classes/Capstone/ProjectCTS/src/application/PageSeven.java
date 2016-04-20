package application;

import java.util.regex.*;

import character.*;
import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.ChoiceBox;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.Tooltip;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.HBox;
import javafx.scene.layout.VBox;
import javafx.scene.text.Font;
import javafx.scene.text.FontWeight;
import javafx.scene.text.Text;
import javafx.stage.Stage;

public class PageSeven implements Page{
	private Stage primaryStage;
	private final TableView<Item> table = new TableView<>();
	private final ObservableList<String> itemBag = FXCollections.observableArrayList();
	private Inventory inv = Model.controller.getCharacter().getInventory();

	@FXML
	private Button next;	
	@FXML	
	private Button clear;
	@FXML
	private Button go_back;
	
	
	
	@Override
	public int getPageLevel() {
		return 7;
	}
	
	@Override
	public Stage getStage(Stage primary) {
		try {
			// Load CharacterName.
			this.primaryStage = primary;
			FXMLLoader loader = new FXMLLoader();
			loader.setLocation(this.getClass().getResource("backdrop.fxml"));
			loader.setController(this);
			BorderPane items = (BorderPane) loader.load();
			GridPane grid4 = new GridPane();
			initialize(grid4);
			items.setCenter(grid4);
			Scene scene = new Scene(items);
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
	
	private boolean hasGoldLeft() {
		boolean result = false;
		
		if (inv.getPurse_Copper() > 0 || inv.getPurse_Silver() > 0 || inv.getPurse_Gold() > 0 || inv.getPurse_Platinum() > 0) {
			result = true;
		}
		
		return result;
	}

	@FXML
	public void nextCalled() {
		if (hasGoldLeft()) {
			int response = -1;
			Dialog dialog = new Dialog("You still have coin left.\n\tAre you sure you have everything?");
			response = dialog.showDialog(Dialog.YesNo);
			
			if (response == Dialog.Buttons.YES) {
				for (String item : itemBag){
					String itemName = "";
					for (int i = 0; i < item.length(); i++) {
						if (item.charAt(i) == '(')
							break;
						itemName += item.charAt(i);
					}
					inv.getItemList().add(Model.lookupItems(itemName));
				}
				Model.finished.set(6, 1);
				Model.controller.nextStage();
			}
		} else {
			Dialog dialog = new Dialog("Are you sure you have everything?");
			int response = dialog.showDialog(Dialog.YesNo);
			
			if (response == Dialog.Buttons.YES) {
				for (String itemName : itemBag){
					Item item = Model.lookupItems(itemName);
					if (item instanceof Armor) {
						int dexMod = Attributes.getModifier(Model.controller.getCharacter().getAttributeList().getOrDefault("Dexterity", -5));
						if(((Armor)item).getItem_MaxDex() < dexMod)
							Model.controller.getCharacter().setTempMax("Dexterity", ((Armor)item).getItem_MaxDex());
						if (((Armor)item).getItem_MaxSpeed() < Model.controller.getCharacter().getSpeed()) 
							Model.controller.getCharacter().setTempMax("Speed", ((Armor)item).getItem_MaxSpeed());
					}
					inv.getItemList().add(item);
				}
				Model.finished.set(6, 1);
				Model.controller.nextStage();
			}
		}
	}
	
	@FXML
	public void prevCalled() {
		Model.controller.prevStage();
	}
	
	//@FXML
	@SuppressWarnings("unchecked")
	public void initialize(GridPane grid4) {
		
		 final ObservableList<Item> items = FXCollections.observableArrayList();
		//Store Selection
	     final ChoiceBox<String> choice = new ChoiceBox<String>();
		 for (Item item : Model.items) {
			 if (!choice.getItems().contains(item.getItem_type()))
				 choice.getItems().add(item.getItem_type());
			 if (item.getItem_type().equals("Goods"))
				 items.add(item);
		 }
		 
        grid4.setAlignment(Pos.CENTER);
        grid4.setHgap(10);
        grid4.setVgap(15);
        grid4.setPadding(new Insets(20, 20, 20, 20));
        
		//Text, Labels, and Text Fields
        Text scenetitle4 = new Text("Character Inventory");
        scenetitle4.setFont(Font.font("Tahoma", FontWeight.NORMAL, 20));
        grid4.add(scenetitle4, 1, 0, 2, 1);
        
        Label Shop = new Label("Shop Type: ");
        grid4.add(Shop, 0, 1);
        
        Label ShopTable = new Label("Shop Table: ");
        grid4.add(ShopTable, 0, 2);
        
        Label inventory = new Label("Inventory: ");
        grid4.add(inventory, 0, 4);
        
        String temp = updateBalance();
        final Label goldBalance = new Label(temp);
        grid4.add(goldBalance, 0, 3);
        
        
        //Table View
        table.setEditable(true);
 
        TableColumn<Item, String> itemName = new TableColumn<Item, String>("Item Name");
        itemName.setMinWidth(150);
        itemName.setCellValueFactory(
            new PropertyValueFactory<Item, String>("Item_name"));
        
        TableColumn<Item, String> description = new TableColumn<Item, String>("Item Description");
        description.setMinWidth(250);
        description.setCellValueFactory(
            new PropertyValueFactory<Item, String>("Item_description"));
        
        TableColumn<Item, String> price = new TableColumn<Item, String>("Price");
        price.setMinWidth(100);
        price.setCellValueFactory(
            new PropertyValueFactory<Item, String>("Formatted_Cost"));
        
        table.getColumns().addAll(itemName, description, price);
 
        final VBox vbox = new VBox();
        vbox.setSpacing(5);
        vbox.setPadding(new Insets(10, 0, 0, 10));
        vbox.getChildren().addAll(table);
        
        grid4.add(vbox, 1, 2);
        
        grid4.add(choice, 1, 1);
        choice.setTooltip(new Tooltip("Select the store of your choice"));
        
        choice.getSelectionModel().selectedItemProperty().addListener(new ChangeListener<String>() {
			@Override
			public void changed(ObservableValue<? extends String> arg0,
					String arg1, String arg2) {
				table.getItems().clear();
				for (Item item : Model.items) {
	               if(item.getItem_type().equals(arg2) && isAffordable(item.getItem_cost()))
	            	  table.getItems().add(item);
	        	}
			}
		});

        choice.getSelectionModel().selectFirst();
        
        //Inventory/Item Bag List        
        final ListView<String> itemBagList = new ListView<String>(itemBag);
        itemBagList.setPrefSize(100, 250);
        itemBagList.setEditable(true);
        
        grid4.add(itemBagList, 1, 4);
        
        //Reveal Grid Lines
        //grid4.setGridLinesVisible(true);
        
        //Purchase Item Button
        Button buyBtn = new Button("Purchase");
        HBox BuyHbBtn = new HBox(10);
        BuyHbBtn.setAlignment(Pos.BOTTOM_RIGHT);
        BuyHbBtn.getChildren().add(buyBtn);
        grid4.add(BuyHbBtn, 1, 3);
        
        buyBtn.setOnAction(new EventHandler<ActionEvent>() {
			@Override
			public void handle(ActionEvent arg0) {
				try {
		            Item itemSelect = table.getSelectionModel().getSelectedItem();
		            double costSelect = itemSelect.getItem_cost();
		            
		            if (isAffordable(costSelect)) {
	            		int count = 1;
	            		int index = 0;
	            		for (String itemName : itemBag) {
	            			Pattern pattern = Pattern.compile(itemSelect.getItem_name() + "(\\( (\\d+)\\))?");
	            			Matcher matcher = pattern.matcher(itemName);
	            			if (matcher.matches()) {
	            				index = itemBag.indexOf(itemName);
	            				String value = "";
	            				try {
	            					if (matcher.group(1) != null) {
	            						
	            						String match = matcher.group(1);
	            						for (int i = 0; i < match.length();i++) {
	            							try {
	            								if (Character.isDigit(match.charAt(i)))
	            									value += match.charAt(i);
	            							} catch (Exception e) {
	            								
	            							}
	            						}
	            					}
	            					count += Integer.parseInt(value);
	            				} catch (Exception e) {
	            					count ++;
	            				}
	            			}
	            		}
	            		
		            	if (count > 1) {
		            		itemBag.remove(index);
		            		itemBag.add(itemSelect.getItem_name() + "( " + count + ")");
		            	}
		            	else
		            	itemBag.add(itemSelect.getItem_name());
		            	
		            	inv.removeGold(costSelect);
			            String temp = updateBalance();
			            goldBalance.setText(temp);
		            }
		        } catch (NullPointerException e) {
		        	Dialog dialog = new Dialog("No item selected!");
		    		dialog.showDialog(Dialog.Yes);
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
        });
	}
	
	private String updateBalance() {
		Inventory inv = Model.controller.getCharacter().getInventory();
		inv.normalizePurse();
        String temp = Integer.toString(inv.getPurse_Copper()) + "cp  " + Integer.toString(inv.getPurse_Silver()) + "sp  " + 
  			  Integer.toString(inv.getPurse_Gold()) + "gp  " + Integer.toString(inv.getPurse_Platinum()) + "pp\t";

		return temp;
	}

	private boolean isAffordable(double cost) {
		boolean ret = true;
		boolean platinum = false;
		boolean gold = false;
		boolean silver = false;
		Inventory inv = Model.controller.getCharacter().getInventory();
		while (cost > .0001) {
			if (cost >= 100) {
				ret = ret && ((inv.getPurse_Platinum() - (int)(cost / 100)) >= 0);
				platinum = true;
				cost -= (int)(cost / 100) * 100;
			} else if (cost >= 1) { 
				if (inv.getPurse_Gold() == 0 && !platinum) {
					//Carry from Platinum
					ret = ret && ((inv.getPurse_Platinum() > 0));
				} else {
					ret = ret && ((inv.getPurse_Gold() - (int)cost) >= 0);
					gold = true;
				}
				cost -= (int)cost;
			} else if (cost >= .01) {
				if (inv.getPurse_Silver() == 0 && !platinum && !gold) {
					//Carry from Silver
					ret = ret && (inv.getPurse_Platinum() > 0 || inv.getPurse_Gold() > 0);
				} else {
					ret = ((inv.getPurse_Silver() - (int)(cost * 100)) >= 0);
					silver = true;
				}
				cost -= (int)(cost * 100);
			} else  if (cost >= .0001){
				if (inv.getPurse_Copper() == 0 && !platinum && !gold && !silver) {
					ret = ret && (inv.getPurse_Platinum() > 0 || inv.getPurse_Gold() > 0 || inv.getPurse_Silver() > 0);
				} else {
					ret = ((inv.getPurse_Copper() - (int)(cost * 10000)) >= 0);
				}
				cost -= (int)(cost * 10000);
			}
		}
		
		return ret;
	}

}
