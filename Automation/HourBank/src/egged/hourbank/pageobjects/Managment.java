package egged.hourbank.pageobjects;
import java.util.List;

import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.FindBys;
import org.openqa.selenium.support.How;

public  class Managment {

	private static WebElement element;
	static boolean flag = true;
	static int i;
	static int j;
	//final WebDriver driver;

	@FindBy(how = How.ID, using = "btnShow")
	public WebElement btnShow;
	
	
	public static WebElement  btnshow1 (WebDriver driver )  {
		
		 element=driver.findElement(By.id("dfdsfdsf"));
		 return element;
				 
				 	
	}

	
	
	@FindBy(how = How.ID, using = "MenuModel_MitkanName_KodYechida")
	public WebElement mitkanName;

	@FindBy(how = How.ID, using = "btnUpdate")
	public WebElement btnUpdate;
	
	@FindBy(how = How.ID, using = "lblIpus")
	public WebElement lblReset;
	
	@FindBy(how = How.CLASS_NAME, using = "DisabledIpus")
	public WebElement lblResetDisabled;

	@FindBy(how = How.ID, using = "cancel")
	public WebElement btnUnDo;
	
	@FindBy(how = How.CLASS_NAME, using = "DisabledLink")
	public WebElement btnUnDoDisabled;

	@FindBy(how = How.ID, using = "btnYes")
	public WebElement btnYes;

	@FindBy(how = How.ID, using = "btnNo")
	public WebElement btnNo;

	@FindBy(how = How.ID, using = "btnYesSave")
	public WebElement btnSaveMichsaYes;

	@FindBy(how = How.ID, using = "btnNoSave")
	public WebElement btnSaveMichsaNo;

	@FindBy(how = How.ID, using = "okbtn")
	public static WebElement btnAccept;

	@FindBy(how = How.ID, using = "btnGridOk")
	public WebElement btnAcceptSuccess;

	@FindBy(how = How.ID, using = "MichsaCur")
	public WebElement typeMichsa;
	
	@FindBy(how = How.ID, using = "IconKds")
	public static WebElement lnkKds;
	
	@FindBy(how = How.ID, using = "ctl00_upHeader")
	public WebElement KdsHeader;
	
	@FindBy(how = How.ID, using = "lblAuto")
	public WebElement lblAutoAllocation;
	
	@FindBy(how = How.ID, using = "btnAuto")
	public WebElement btnAutoAllocation;
	
	@FindBy(how = How.CLASS_NAME, using = "DisabledCal")
	public WebElement lblAutoAllocationDisabled;
	
	@FindBy(how = How.ID, using = "rbTichnunPrev")
	public WebElement radioPrevPlan;
	
	@FindBy(how = How.ID, using = "rbBizuaPrev")
	public WebElement radioPrevActual;
	
	@FindBy(how = How.ID, using = "rbTichnunCur")
	public WebElement radioCurActual;
	
	@FindBy(how = How.CLASS_NAME, using = "PurpleTextLink")
	public WebElement daysLeft;
	
	@FindBy(how = How.ID, using = "btnPrevMonth")
	public WebElement btnPrevMonth;
	
	@FindBy(how = How.ID, using = "btnNextMonth")
	public WebElement btnNextMonth;
	
	@FindBy(how = How.ID, using = "SelectedMonth")
	public WebElement listDate;
	
	@FindBy(how = How.ID, using = "MisparIshi")
	public static WebElement searchAutoComplete;
	
	@FindBy(how = How.CLASS_NAME, using = "SearchBG")
	public static WebElement btnAutoComplete;
	
	@FindBy(how = How.ID, using = "MisparIshi-list")
	public static WebElement listAutoComplete;
	
	@FindBy(how = How.ID, using = "k-item")
	public WebElement itemMisparIshi;
	
	@FindBy(how = How.ID, using = "MisparIshi_option_selected")
	public static WebElement itemValueSelected;
	
	@FindBy(how = How.ID, using = "dialog-message")
	public WebElement autoCompleteMessage;
	
	@FindBy(how = How.CLASS_NAME, using = "clickable")
	public WebElement highlightTr ;
	
	
	@FindBy(how = How.XPATH, using = "//tr[@class='clickable']//td[@id='tdName']")
	public static WebElement  autoCompleteName ;
	

	
	 @FindBys({
		    @FindBy(id = "MenuModel_MitkanName_KodYechida"),
		    @FindBy(tagName = "option")
		    })
		    public static List<WebElement> allListValues;
	
	
	
	 public static String   isMitkanSelected  ()
	 
	 {
		  String returnValue=null;
		 for (WebElement AllValues : Managment.allListValues)

		{

			// System.out.println(AllValues.getAttribute("value"));
			System.out.println(AllValues.getText());
			System.out.println(AllValues.isSelected());
			
			


		if (AllValues.isSelected() == true)
				

			{
                
			returnValue=AllValues.getAttribute("value");
				break; 
				

			}

			else

			{
				continue;

			}
		
		}
	 return returnValue;
	 
	 

		}
	
	 
	
	public static void  clickLinkTokds ()  {
		
		
		Managment.lnkKds.click();
		
		
	}
	
	
	public static void clickAutoComplete ()   {
		
		Managment.btnAutoComplete.click();
		
		
	}
	
	
	public static void typeAutoComplete (String keys )   {
		
		Managment.searchAutoComplete.clear();
		Managment.searchAutoComplete.sendKeys(keys);
		
		
	}
	
	
	
	public static void clickAccept ()  {
		
		Managment.btnAccept.click();
		
	}
	
	
	
	
	
	public static void setNameAutocomplete    () throws InterruptedException  {
		
		
		String [] ArrayShem={"à","á","â","ã","ä","å","æ","ç","è ","é","ë","ì","î" };
		i=0;
		
		
		//System.out.println(managment.listAutoComplete.getAttribute("style"));
		
		while (flag&&i<=ArrayShem.length) {
			
			String lettter= ArrayShem[i];
			Managment.searchAutoComplete.sendKeys(String.valueOf(lettter));

			Thread.sleep(300);
			

			String style = Managment.listAutoComplete.getAttribute("style");

			//System.out.println(managment.listAutoComplete.getAttribute("style"));

			if (style.contains("block"))

			{

				flag = false;
				Managment.searchAutoComplete.sendKeys(Keys.ARROW_DOWN);
				//Managment.typeAutoComplete(Keys.ARROW_DOWN);
				Managment.itemValueSelected.click();
				//System.out.println(Managment.searchAutoComplete.getAttribute("value"));
				
				

			}

			else {

				Managment.searchAutoComplete.clear();

			}
			i++;

		}
		
		
		
		
		
		
		
	}
	
	
	
	
	
	public static void setMisparishiAutocomplete () throws InterruptedException   {
		
		flag=true;
		j=1;
		
		while (flag) {

			Managment.searchAutoComplete.sendKeys(String.valueOf(j));
			

			Thread.sleep(300);
			

			String style = Managment.listAutoComplete.getAttribute("style");

			//System.out.println(managment.listAutoComplete.getAttribute("style"));

			if (style.contains("block"))

			{

				flag = false;
				Managment.searchAutoComplete.sendKeys(Keys.ARROW_DOWN);
				Managment.itemValueSelected.click();
				//System.out.println(Managment.searchAutoComplete.getAttribute("value"));
				
				

			}

			else {

				Managment.searchAutoComplete.clear();

			}
			j++;

		}
		
		

		
		
	}
	
	
	
	
	

	
	

	public static WebElement clickMichsa(WebDriver driver, String elname) {

		element = driver.findElement(By.id(elname));

		return element;

	}















	
	// public Budget(WebDriver driver) { 
	// this.driver=driver; }
	
	
	
	
}
