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
	
	
	@FindBy(how = How.ID, using = "lblSubtract")
	public static WebElement lblReduction ;
	
	
	
	@FindBy(how = How.ID, using = "KodMitkanIn")
	public static WebElement listMitkanIn ;
	
	
	@FindBy(how = How.ID, using = "inputKamut")
	public static WebElement inputKamut ;
	
	
	@FindBy(how = How.ID, using = "inputReson")
	public static WebElement inputReason ;
	
	
	@FindBy(how = How.ID, using = "btnAuto")
	public static WebElement btnUpdate ;
	
	
	@FindBy(how = How.ID, using = "btnNewBudget")
	public static WebElement btnUpdateNewBudget ;
	
	
	@FindBy(how = How.ID, using = "btnGria")
	public static WebElement btnUpdateReduction ;
	
	
	@FindBy(how = How.ID, using = "lblAdd")
	public static WebElement lblAddBudget ;
	
	
	@FindBy(how = How.ID, using = "KodMitkan")
	public static WebElement listMitkan ;
	
	
	
	@FindBy(how = How.ID, using = "KodTakziv")
	public static WebElement listBudget ;
	
	
	@FindBy(how = How.ID, using = "addNew")
	public static WebElement lblCreateBudget ;
	
	
	
	@FindBy(how = How.ID, using = "inputKamutNew")
	public static WebElement inputKamutNew ;
	
	
	
	@FindBy(how = How.ID, using = "inputResonNew")
	public static WebElement inputReasonNew ;
	
	
	@FindBy(how = How.ID, using = "inputName")
	public static WebElement inputBudgetName ;
	
	
	
	
	
	

	
	
	
	
	
	
	
	
	
	public static void  clickAddBudget()  {
		
		
		lblAddBudget.click();
		
		
	}
	
	
	
	
	public static void  clickNiud()  {
		
		
		lblNiud.click();
		
		
	}
	
	
	
	public static void  clickReduction()  {
		
		
		lblReduction.click();
		
		
	}
	
	
	
	
	
	
	public static void  selectOutToIn (String out, String In)   {
		
		

		Select droplist = new Select(Mobility.listMitkanOut);
		droplist.selectByValue(out);
		
		Select droplist1 = new Select(Mobility.listMitkanIn);
		droplist1.selectByValue(In);
		
		
		
		
		
	}
	
	
	
	public static void  selectMitkan (String mitkan)   {
		
		
		
		Select droplist = new Select(Mobility.listMitkan);
		droplist.selectByValue(mitkan);
		
		
		
		
		
	}
	
	
	
	
	public static void  selectBudget (String kodbudget)   {
		
		
		
		Select droplist = new Select(Mobility.listBudget);
		droplist.selectByValue(kodbudget);
		
			
		
	}
	
	
	
	
	public static void clickBtnUpdate()  {
		
		
		btnUpdate.click();
		
		
		
	}
	
	
	
	
	
	public static void typeKamut(String value)  {
		
		inputKamut.clear();
		inputKamut.sendKeys(value);
		
		
	}
	
	
	public static void typeReason(String value)  {
		
		inputReason.clear();
		inputReason.sendKeys(value);
		
		
	}
	
	
	
	public static void typeKamutNew(String value)  {
		
		inputKamutNew.clear();
		inputKamutNew.sendKeys(value);
		
		
	}
	
	
	
	public static void typeReasonNew(String value)  {
		
		inputReasonNew.clear();
		inputReasonNew.sendKeys(value);
		
		
	}
	
	
	
	
	public static void typeBudgetName(String value)  {
		
		inputBudgetName.clear();
		inputBudgetName.sendKeys(value);
		
		
	}
	
	
	
	
	
	public static void clickBtnReduction()  {
		
		
		btnUpdateReduction.click();
		
		
	}
	
	
	
	
	public static void clickCreateBudget()  {
		
		
		lblCreateBudget.click();
		
		
	}
	
	
	
	public static void clickBtnUpdateBudget()  {
		
		
		btnUpdateNewBudget.click();
		
		
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	

	
	


}
