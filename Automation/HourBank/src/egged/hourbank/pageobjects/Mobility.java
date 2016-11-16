package egged.hourbank.pageobjects;

import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;
import org.openqa.selenium.support.ui.Select;

import egged.hourbank.utils.Base;

public class Mobility extends Base {
	
	

	
	@FindBy(how = How.ID, using = "SelectedEzor")
	public static WebElement listEzor;
	
	

	@FindBy(how = How.ID, using = "lblNiyud")
	public static WebElement lblNiud;
	
	
	@FindBy(how = How.ID, using = "KodMitkanOut")
	public static WebElement listMitkanOut ;
	
	
	@FindBy(how = How.ID, using = "KodMitkanIn")
	public static WebElement listMitkanIn ;
	
	
	@FindBy(how = How.ID, using = "inputKamut")
	public static WebElement inputKamut ;
	
	
	@FindBy(how = How.ID, using = "inputReson")
	public static WebElement inputReason ;
	
	
	@FindBy(how = How.ID, using = "btnAuto")
	public static WebElement btnupdate ;
	
	
	@FindBy(how = How.ID, using = "lblAdd")
	public static WebElement lblAddBudget ;
	
	
	@FindBy(how = How.ID, using = "KodMitkan")
	public static WebElement listMitkan ;
	
	@FindBy(how = How.ID, using = "KodTakziv")
	public static WebElement listBudget ;

	
	
	
	
	
	
	
	
	
	public static void  clickNiud()  {
		
		
		lblNiud.click();
		
		
	}
	
	
	
	
	
	public static void  selectOutToIn (String out, String In)   {
		
		

		Select droplist = new Select(Mobility.listMitkanOut);
		droplist.selectByValue(out);
		
		Select droplist1 = new Select(Mobility.listMitkanIn);
		droplist1.selectByValue(In);
		
		
		
		
		
	}
	
	
	public static void clickBtnUpdate()  {
		
		
		btnupdate.click();
		
		
		
	}
	
	
	
	
	
	public static void typeKamut(String value)  {
		
		inputKamut.clear();
		inputKamut.sendKeys(value);
		
		
	}
	
	
	public static void typeReason(String value)  {
		
		inputReason.clear();
		inputReason.sendKeys(value);
		
		
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	

	
	


}
