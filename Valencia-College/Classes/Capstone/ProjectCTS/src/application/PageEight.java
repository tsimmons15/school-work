package application;

import java.net.URL;
import java.util.ResourceBundle;

import character.*;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.image.ImageView;
import javafx.scene.layout.GridPane;
import javafx.scene.text.Text;
import javafx.stage.Stage;

public class PageEight implements Initializable {
	private Stage primaryStage;
	private Characters currChar;

	@FXML //fx:id="reviewAccept"
	private Button reviewAccept;
	@FXML //fx:id="reviewDiscard"
	private Button reviewDiscard;
	@FXML //fx:id="reviewGoBack"
	private Button reviewGoBack;
	
	@FXML //fx:id="logo"
	private ImageView logo;
	
	@FXML //fx:id="name"
	private Label name;
	@FXML //fx:id="race"
	private Label race;
	@FXML //fx:id="alignment"
	private Label alignment;
	@FXML //fx:id="deity"
	private Label deity;
	@FXML //fx:id="size"
	private Label size;
	@FXML //fx:id="age"
	private Label age;
	@FXML //fx:id="gender"
	private Label gender;
	@FXML //fx:id="height"
	private Label height;
	@FXML //fx:id="weight"
	private Label weight;
	@FXML //fx:id="eyes"
	private Label eyes;
	@FXML //fx:id="hair"
	private Label hair;
	@FXML //fx:id="skin"
	private Label skin;
	@FXML //fx:id="initTotal"
	private Label initTotal;
	@FXML //fx:id="initDexMod"
	private Label initDexMod;
	@FXML //fx:id="initMiscMod"
	private Label initMiscMod;
	@FXML //fx:id="charSpeed"
	private Label charSpeed;
	@FXML //fx:id="nonlethal"
	private Label nonLethal;
	@FXML //fx:id="hpTotal"
	private Label hpTotal;
	@FXML //fx:id="currHP"
	private Label currHP;
	@FXML //fx:id="acTotal"
	private Label acTotal;
	@FXML //fx:id="armorBonus"
	private Label armorBonus;
	@FXML //fx:id="shieldBonus"
	private Label shieldBonus;
	@FXML //fx:id="acDexMod"
	private Label acDexMod;
	@FXML //fx:id="acSizeMod"
	private Label acSizeMod;
	@FXML //fx:id="acNatArmor"
	private Label acNatArmor;
	@FXML //fx:id="acDeflectBonus"
	private Label acDeflectBonus;
	@FXML //fx:id="acMiscMod"
	private Label acMiscMod;
	@FXML //fx:id="acTouch"
	private Label acTouch;
	@FXML //fx:id="acFlatFoot"
	private Label acFlatFoot;
	@FXML //fx:id="spellResistance"
	private Label spellResistance;
	@FXML //fx:id="baseAttackBonus"
	private Label baseAttackBonus;
	@FXML //fx:id="grappleTotal"
	private Label grappleTotal;
	@FXML //fx:id="grappleBAB"
	private Label grappleBAB;
	@FXML //fx:id="grappleStrMod"
	private Label grappleStrMod;
	@FXML //fx:id="grappleSizeMod"
	private Label grappleSizeMod;
	@FXML //fx:id="grappleMiscMod"
	private Label grappleMiscMod;
	@FXML //fx:id="fortTotal"
	private Label fortTotal;
	@FXML //fx:id="fortBaseSave"
	private Label fortBaseSave;
	@FXML //fx:id="fortAttrModifier"
	private Label fortAttrModifier;
	@FXML //fx:id="fortMagicModifier"
	private Label fortMagicModifier;
	@FXML //fx:id="fortMiscModifier"
	private Label fortMiscModifier;
	@FXML //fx:id="fortTempModifier"
	private Label fortTempModifier;
	@FXML //fx:id="willTotal"
	private Label willTotal;
	@FXML //fx:id="willBaseSave"
	private Label willBaseSave;
	@FXML //fx:id="willAttrModifier"
	private Label willAttrModifier;
	@FXML //fx:id="willMagicModifier"
	private Label willMagicModifier;
	@FXML //fx:id="willMiscModifier"
	private Label willMiscModifier;
	@FXML //fx:id="willTempModifier"
	private Label willTempModifier;
	@FXML //fx:id="refTotal"
	private Label refTotal;
	@FXML //fx:id="refBaseSave"
	private Label refBaseSave;
	@FXML //fx:id="refAttrModifier"
	private Label refAttrModifier;
	@FXML //fx:id="refMagicModifier"
	private Label refMagicModifier;
	@FXML //fx:id="refMiscModifier"
	private Label refMiscModifier;
	@FXML //fx:id="refTempModifier"
	private Label refTempModifier;
	@FXML //fx:id="currCampaign"
	private Label currCampaign;
	@FXML //fx:id="currExperience"
	private Label currExperience;
	@FXML //fx:id="currLoad"
	private Label currLoad;
	@FXML //fx:id="currCarryingCapacity"
	private Label currCarryingCapacity;
	@FXML //fx:id="clericDomain"
	private Label clericDomain;
	@FXML //fx:id="wizSchool"
	private Label wizSchool;
	@FXML //fx:id="sorcBloodline"
	private Label sorcBloodline;
	@FXML //fx:id="spellSave"
	private Label spellSave;
	@FXML //fx:id="spellFailure"
	private Label spellFailure;
	@FXML //fx:id="platinumPieces"
	private Label platinumPieces;
	@FXML //fx:id="goldPieces"
	private Label goldPieces;
	@FXML //fx:id="silverPieces"
	private Label silverPieces;
	@FXML //fx:id="copperPieces"
	private Label copperPieces;

	@FXML //fx:id="currInventory"
	private ListView<String> currInventory;
	@FXML //fx:id="knownLang"
	private ListView<String> knownLang;
	@FXML //fx:id="currFeats"
	private ListView<String> currFeats;
	@FXML //fx:id="spellBook"
	private ListView<String> spellBook;
	@FXML //fx:id="followers"
	private ListView<String> followers;
	@FXML //fx:id="classesList"
	private ListView<String> classesList;
	@FXML //fx:id="attributeScores"
	private ListView<String> attributeScores;
	@FXML //fx:id="equippedArmor"
	private ListView<String> equippedArmor;
	@FXML //fx:id="damageReduction"
	private ListView<String> damageReduction;
	
	@FXML //fx:id="weaponList"
	private GridPane weaponList;
	@FXML //fx:id="skillList"
	private GridPane skillList;
	

	
	public int getPageLevel() {
		return 8;
	}
		
	public Stage getStage() {
		try {
			this.primaryStage = new Stage();
			FXMLLoader loader = new FXMLLoader();
			loader.setLocation(PageEight.class.getResource("Review.fxml"));
			SplitPane Review = (SplitPane) loader.load();
			Scene scene = new Scene(Review);
			primaryStage.setScene(scene);
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
	public void prevCalled() {
		System.out.println("Previous called");
	}
	
	@FXML
	public void finishCalled() {
		System.out.println("Finish called");
	}
	
	@FXML
	public void startOverCalled() {
		System.out.println("StartOverCalled");
		Model.controller.startOverCalled();
	}

	public void initialize(URL arg0, ResourceBundle arg1) {
		currChar = Model.controller.getCharacter();
		char charSize = 'M';
		if (currChar.containsTempMax("Speed") && currChar.getTempMax("Speed", 10000) < currChar.getSpeed())
			charSpeed.setText(currChar.getTempMax("Speed", 10000) + "");
		else 
			charSpeed.setText(currChar.getSpeed() + "");
		if (currChar.getName() != null) 
			name.setText(currChar.getName());
		if (currChar.getRace() != null) {
			race.setText(currChar.getRace().getRace_name());
			charSize = currChar.getSize();
			switch(charSize) {
			case 'M':
				size.setText("Medium");
				break;
			case 'L':
				size.setText("Large");
				break;
			case 'S':
				size.setText("Small");
				break;
			}
		}
		if (currChar.getAttributeList().size() > 0)
			for (String attr : currChar.getAttributeList().keySet()){
				attributeScores.getItems().add(attr + "  " + currChar.getAttributeList().get(attr) + "  " + Attributes.getModifier(currChar.getAttributeList().get(attr)));
				switch (attr) {
				case "Strength":
					int strengthMod = 0;
					if (currChar.containsTempMax("Strength")) {
						int maxStr = currChar.getTempMax("Strength", 100000);
						int strMod = Attributes.getModifier(currChar.getAttributeList().get(attr));
						strengthMod = (maxStr < strMod) ? maxStr : strMod;
					}
					grappleStrMod.setText(strengthMod + "");
					break;
				case "Constitution":
					
					break;
				case "Dexterity":
					int dexterityMod = 0;
					if (currChar.containsTempMax("Dexterity")) {
						int maxDex = currChar.getTempMax("Dexterity", 100000);
						int dexMod = Attributes.getModifier(currChar.getAttributeList().get(attr));
						strengthMod = (maxDex < dexMod) ? maxDex : dexMod;
					}
					initDexMod.setText(dexterityMod + "");
					initTotal.setText(dexterityMod + "");
					acDexMod.setText(dexterityMod + "");
					break;
				case "Intelligence":
					
					break;
				case "Wisdom":
					
					break;
				case "Charisma":
					
					break;
				}
			}
		if (currChar.getClasses().size() > 0) {
			for(Classes c : currChar.getClasses().keySet()) {
				classesList.getItems().add(c.getClass_name() + "\t" + currChar.getClasses().get(c));
			}
			currHP.setText(currChar.getHealth() + "");
			hpTotal.setText(currChar.getHealth() + "");
			
			//Classes need informatin from skills, classes and attributes..
			if (currChar.getAttributeList().size() > 0 && currChar.getSkillList().size() > 0) {
				int rowIndex = 0, columnIndex = 0;
				for (Skills skill : currChar.getSkillList().keySet()) {
					if (currChar.getClasses().firstKey().isClassSkill(skill.getSkill_name())) {
						skillList.add(new Label("X"), columnIndex++, rowIndex);
					} else {
						skillList.add(new Label("X"), columnIndex++, rowIndex);
					}
					
					skillList.add(new Label(skill.getSkill_name()), columnIndex++, rowIndex);
					skillList.add(new Label(skill.getSkill_attribute()), columnIndex++, rowIndex);
					int totalValue = 0;
					int attrMod = Attributes.getModifier(currChar.getAttributeList().getOrDefault(skill.getSkill_attribute(), 1));
					int rank = currChar.getSkillList().get(skill);
					totalValue = attrMod + rank;
					skillList.add(new Label(totalValue + ""), columnIndex++, rowIndex);
					skillList.add(new Label("="), columnIndex++, rowIndex);
					skillList.add(new Label(attrMod + ""), columnIndex++, rowIndex);
					skillList.add(new Label("+"), columnIndex++, rowIndex);
					skillList.add(new Label(rank + ""), columnIndex++, rowIndex);
					skillList.add(new Label("+"), columnIndex++, rowIndex);
					skillList.add(new Label("0"), columnIndex++, rowIndex);
					
					columnIndex = 0;
					rowIndex++;
				}
			}
		}
		if (currChar.getAlignment() != null) {
			String text = "";
			for (char c : currChar.getAlignment()) {
				switch (Character.toLowerCase(c)) {
				case 'l':
					text += "Lawful";
					break;
				case 'e':
					text += "Evil";
					break;
				case 'n':
					text += "Neutral";
					break;
				case 'g':
					text += "Good";
					break;
				case 'c':
					text += "Chaotic";
					break;
				}
				text += " ";
			}
			alignment.setText(text);
		}
		if (currChar.getReligion() != null)
			deity.setText(currChar.getReligion().getDeity_name());
		
		acSizeMod.setText(getSizeModifier(charSize) + "");
		grappleSizeMod.setText(getSizeModifier(charSize) + "");
		age.setText(currChar.getAge() + "");
		if (currChar.getGender() == 'F') 
			gender.setText("Female");
		else
			gender.setText("Male");
		if (currChar.getHeight() != null) {
			String text = currChar.getHeight()[0] + "'-" + currChar.getHeight()[1] + "\"";
			height.setText(text);
		}
		weight.setText(currChar.getWeight() + "");
		eyes.setText("Brown");
		if(currChar.getHairColor() != null) 
			hair.setText(currChar.getHairColor());
		if (currChar.getSkin() != null)
			skin.setText(currChar.getSkin());
		initMiscMod.setText(((currChar.getInitiative() > 0) ? currChar.getInitiative() : 0) + "");
		initDexMod.setText("0");
		initTotal.setText("0");
		nonLethal.setText("0");
		
		int totalAC = 0;
		int armor = 0;
		int shield = 0;
		int acDex;
		try {
			 acDex = Integer.parseInt(acDexMod.getText());
		} catch (Exception e) {
			acDex = -5;
		}
		int weight = 0;
		int spellFail = 0;
		acNatArmor.setText("0");
		acDeflectBonus.setText("0");
		acMiscMod.setText("0");
		if (currChar.getInventory() != null) {
			int columnIndex = 0;
			int rowIndex = 0;
			if (currChar.getInventory().getItemList() != null) {
				for (Item item : currChar.getInventory().getItemList()) {
					currInventory.getItems().add(item.getItem_name() + "   " + item.getItem_weight());
					weight += item.getItem_weight();
					if (item.getItem_type().contains("Shield") && columnIndex < 9) {
						Shield aShield = (Shield)item;
						spellFail += aShield.getItem_SpellFailure();
						equippedArmor.getItems().add(aShield.getItem_name() + " " + aShield.getItem_ac() + " " + aShield.getItem_weight());
						shield += aShield.getItem_ac();
						weaponList.add(new Text(item.getItem_name() + " Bash"), columnIndex, rowIndex++);
						int baseAttckBonus = currChar.getBaseAttackBonus();
						baseAttackBonus.setText(baseAttckBonus + "");
						int attackBonus = baseAttckBonus + Attributes.getModifier(currChar.getAttributeList().get("Strength")) + getSizeModifier(acSizeMod.getText().charAt(0));
						weaponList.add(new Text(attackBonus+""), columnIndex, rowIndex++);
						weaponList.add(new Text(aShield.getItem_damage()), columnIndex, rowIndex++);
						weaponList.add(new Text("x" + aShield.getItem_critical()), columnIndex, rowIndex++);
						weaponList.add(new Text("-"), columnIndex, rowIndex++);
						weaponList.add(new Text(aShield.getItem_DmgType()), columnIndex, rowIndex);
						rowIndex = 0;
						columnIndex++;
					} else if (item.getItem_type().contains("Armor") && columnIndex < 9) {
						spellFail += ((Armor)item).getItem_SpellFailure();
						equippedArmor.getItems().add(((Armor)item).getItem_name() + " " + ((Armor)item).getItem_ac() + " " + ((Armor)item).getItem_weight());
						armor += ((Armor)item).getItem_ac();
					} else if ((item.getItem_type().contains("Weapon") || item.getItem_type().contains("Range")) && columnIndex < 9) {
						weaponList.add(new Text(item.getItem_name()), columnIndex, rowIndex++);
						int baseAttckBonus = currChar.getBaseAttackBonus();
						baseAttackBonus.setText(baseAttckBonus + "");
						int attackBonus = baseAttckBonus + Attributes.getModifier(currChar.getAttributeList().get("Strength")) + getSizeModifier(acSizeMod.getText().charAt(0));
						weaponList.add(new Text(attackBonus+""), columnIndex++, rowIndex);
						weaponList.add(new Text(((Weapon)item).getItem_damage()), columnIndex++, rowIndex);
						weaponList.add(new Text("x" + ((Weapon)item).getItem_critical()), columnIndex++, rowIndex);
						if (item instanceof Ranged) {
							weaponList.add(new Text(((Ranged)item).getItem_range() + ""), columnIndex++, rowIndex);
						} else {
							weaponList.add(new Text("-"), columnIndex++, rowIndex);
						}
						weaponList.add(new Text(((Weapon)item).getItem_DmgType()), columnIndex, rowIndex);
						rowIndex++;
						columnIndex = 0;
					}
				}
			}
			totalAC = 10 + armor + shield + acDex + getSizeModifier(acSizeMod.getText().charAt(0));
			platinumPieces.setText(currChar.getInventory().getPurse_Platinum() + "pp");
			goldPieces.setText(currChar.getInventory().getPurse_Gold() + "gp");
			silverPieces.setText(currChar.getInventory().getPurse_Silver() + "sp");
			copperPieces.setText(currChar.getInventory().getPurse_Copper() + "cp");
		}
		acTotal.setText(totalAC + "");
		acFlatFoot.setText((10 + armor + shield + getSizeModifier(acSizeMod.getText().charAt(0))) + "");
		armorBonus.setText(armor + "");
		shieldBonus.setText(shield + "");
		acDexMod.setText(acDex + "");
		acTouch.setText((10 + acDex + getSizeModifier(acSizeMod.getText().charAt(0))) + "");
		currLoad.setText(weight + "");
		damageReduction.getItems().add("0");
		spellResistance.setText("0");
		grappleMiscMod.setText("0");
		int totalGrapple = Attributes.getModifier(currChar.getAttributeList().getOrDefault("Strength", -5)) + getSizeModifier(charSize) + currChar.getBaseAttackBonus();
		grappleTotal.setText(totalGrapple + "");
		grappleBAB.setText(currChar.getBaseAttackBonus() + "");
		int totalFort = currChar.getFortitude() + Attributes.getModifier(currChar.getAttributeList().getOrDefault("Constitution", -5));
		fortTotal.setText(totalFort + "");
		fortBaseSave.setText(currChar.getFortitude() + "");
		fortAttrModifier.setText("" + Attributes.getModifier(currChar.getAttributeList().getOrDefault("Constitution", -5)));
		fortMagicModifier.setText("0");
		fortMiscModifier.setText("0");
		fortTempModifier.setText("0");
		int totalWill = currChar.getWillpower() + Attributes.getModifier(currChar.getAttributeList().getOrDefault("Wisdom", -5));
		willTotal.setText(totalWill + "");
		willBaseSave.setText(currChar.getWillpower() + "");
		willAttrModifier.setText("" + Attributes.getModifier(currChar.getAttributeList().getOrDefault("Wisdom", -5)));
		willMagicModifier.setText("0");
		willMiscModifier.setText("0");
		willTempModifier.setText("0");
		int totalRef = currChar.getReflex() + Attributes.getModifier(currChar.getAttributeList().getOrDefault("Dexterity", -5));
		refTotal.setText(totalRef + "");
		refBaseSave.setText(currChar.getReflex() + "");
		refAttrModifier.setText("" + Attributes.getModifier(currChar.getAttributeList().getOrDefault("Dexterity", -5)));
		refMagicModifier.setText("0");
		refMiscModifier.setText("0");
		refTempModifier.setText("0");
		currExperience.setText("" + currChar.getExperience());
		currCarryingCapacity.setText("Medium Load");
		if (currChar.getLanguagesKnown() != null)
			for (Language lang : currChar.getLanguagesKnown()) {
				knownLang.getItems().add(lang.getLanguage_name());
			}
		if (currChar.getFeatList() != null)
			for (Feat feat : currChar.getFeatList()) {
				currFeats.getItems().add(feat.getFeat_name());
			}
		if (currChar.getSpellBook().size() > 0 )
			for (Spells spell : currChar.getSpellBook().keySet()) {
				spellBook.getItems().add(spell.getSpellName() + " " + currChar.getSpellBook().get(spell));
			}
		clericDomain.setText("None");
		wizSchool.setText("None");
		sorcBloodline.setText("None");
		spellFailure.setText(spellFail + "");
		spellSave.setText("0");
		followers.disableProperty().set(true);
	}
	
	private int getSizeModifier(char size) {
		int result = 0;
		
		switch (size) {
		case 'L':
			result = -1;
			break;
		case 'M':
			result = 0;
			break;
		case 'S':
			result = 1;
			break;
		}
		
		return result;
	}
}
