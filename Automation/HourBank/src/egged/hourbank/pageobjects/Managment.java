package egged.hourbank.pageobjects;
import java.util.Calendar;
import java.util.List;
import java.util.Random;
import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindAll;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.FindBys;
import org.openqa.selenium.support.How;
import org.openqa.selenium.support.ui.ExpectedCondition;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.Wait;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.testng.Assert;

import egged.hourbank.utils.Base;
import egged.hourbank.utils.Common;

public  class Managment extends Base {

	private static WebElement element;
	static boolean flag = true;
	static int i;
	static int j;
	final static String symbol = "-";
	static WebElement eltd;
	static WebElement plantd;
	static WebElement actualtd;
	static String nametd;
	static String actualtdname;
	static String plantdname;
	static int  day;
	static String sysdate ;
	static int h = 0;
	static int michsa = 40;
	static int num = 0;
	
	
	
	//public static  WebDriver driver;

	/*@FindBy(how = How.ID, using = "btnShow")
	public WebElement btnShow;*/
	
	
	public static WebElement  btnshow1 (WebDriver driver )  {
		
		 element=driver.findElement(By.id("dfdsfdsf"));
		 return element;
				 
				 	
	}

	
	
	@FindBy(how = How.ID, using = "MenuModel_MitkanName_KodYechida")
	public WebElement mitkanName;

	@FindBy(how = How.ID, using = "btnUpdate")
	public static WebElement btnUpdate;
	
	@FindBy(how = How.ID, using = "lblIpus")
	public static WebElement lblReset;
	
	@FindBy(how = How.CLASS_NAME, using = "DisabledIpus")
	public WebElement lblResetDisabled;

	@FindBy(how = How.ID, using = "cancel")
	public static WebElement btnUnDo;
	
	@FindBy(how = How.CLASS_NAME, using = "DisabledLink")
	public WebElement btnUnDoDisabled;

	@FindBy(how = How.ID, using = "btnYes")
	public static WebElement btnYes;

	@FindBy(how = How.ID, using = "btnNo")
	public static WebElement btnNo;
	
	@FindBy(how = How.ID, using = "dialog-confirm")
	public static WebElement  alertMassage;
	
	@FindBy(how = How.ID, using = "dialog-grid")
	public static WebElement  updateMassage;
		
	@FindBy(how = How.ID, using = "btnYesSave")
	public static WebElement btnSaveMichsaYes;

	@FindBy(how = How.ID, using = "btnNoSave")
	public static WebElement btnSaveMichsaNo;

	@FindBy(how = How.ID, using = "btnGridOk")
	public static WebElement btnAcceptSuccess;

	@FindBy(how = How.ID, using = "MichsaCur")
	public static  WebElement typeMichsa;
	
	@FindBy(how = How.ID, using = "IconKds")
	public static WebElement lnkKds;
	
	@FindBy(how = How.ID, using = "ctl00_upHeader")
	public WebElement KdsHeader;
	
	@FindBy(how = How.ID, using = "lblAuto")
	public static WebElement lblAutoAllocation;
	
	@FindBy(how = How.ID, using = "btnAuto")
	public static  WebElement btnAutoAllocation;
	
	@FindBy(how = How.CLASS_NAME, using = "DisabledCal")
	public WebElement lblAutoAllocationDisabled;
	
	@FindBy(how = How.ID, using = "rbTichnunPrev")
	public static WebElement radioPrevPlan;
	
	@FindBy(how = How.ID, using = "rbBizuaPrev")
	public WebElement radioPrevActual;
	
	@FindBy(how = How.ID, using = "rbTichnunCur")
	public static WebElement radioCurActual;
	
	@FindBy(how = How.CLASS_NAME, using = "PurpleTextLink")
	public WebElement daysLeft;
	
	@FindBy(how = How.ID, using = "btnPrevMonth")
	public static  WebElement btnPrevMonth;
	
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
	
	/*@FindBy(how = How.ID, using = "dialog-message")
	public static WebElement dialogMessage;*/
	
	@FindBy(how = How.CLASS_NAME, using = "clickable")
	public WebElement highlightTr ;
	
	@FindBy(how = How.XPATH, using = "//tr[@class='clickable']//td[@id='tdName']")
	public static WebElement  autoCompleteName ;
	
	@FindAll(@FindBy(how = How.XPATH, using ="//tr[contains(@data-uid,'"
			+ symbol + "')]"))
			
			public static List<WebElement> AllElements;
	
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
	
	
	
	
	
	
	
	
	
	public static void setNameAutocomplete    () throws InterruptedException  {
		
		
		String [] ArrayShem={"א","ב","ג","ד","ה","ו","ז","ח","ט ","י","כ","ל","מ" };
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






	public static void clicklblAutoAllocation() {

		Managment.lblAutoAllocation.click();


	}



	public static void clickradioPrevPlan() {

		Managment.radioPrevPlan.click();


	}
	
	
	
	public static void clickbtnAutoAllocation() {

		Managment.btnAutoAllocation.click();


	}
	
	
	
	public static  int getNumOfRows()  {
		
		
		return Managment.AllElements.size();
		 
	
	
		
	}


	
	
	
	public static void assertPlanTd()  {
		
		int num=Managment.getNumOfRows();
		
		for (i=0;i<num-1;i++) {
			
			nametd = "tdMichsa" + i;
			
			eltd = Managment.clickMichsa(driver,nametd);
			plantdname =  "tdPrevMonth" + i;
			
			
			
			plantd = Managment.clickMichsa(driver,plantdname);
			
			
			
			if (eltd.getAttribute("class").equals("CellEditGrid") == true)
				
				
				
			{
			
				//System.out.println(eltd.getText()+"הקצאת שעות");
				//System.out.println(plantd.getText()+"הקצאה לחודש קודם");
				
				
				Assert.assertEquals(eltd.getText(), plantd.getText());
			
		}
			
		}
		
		
		
		
		
		
	}
	
	
	
	public static void assertActualTd()   {
		
		int num=Managment.getNumOfRows();
		
		for (i=0;i<num-1;i++) {
			
			nametd = "tdMichsa" + i;
			eltd = Managment.clickMichsa(driver,nametd);
			actualtdname =  "tdShaotUsed" + i;
			actualtd = Managment.clickMichsa(driver,actualtdname);
			if (eltd.getAttribute("class").equals("CellEditGrid") == true)
				
				
				
			{
			
				
				String actualtext = actualtd.getText();
						
				String[] actualsplit = actualtext.split(" ");
				
				String actual = actualsplit[0];	
				
				
				System.out.println(actual);
				//System.out.println(actualtd.getText());
				Assert.assertEquals(eltd.getText(),actual);
			
		}
			
		}
		
		
		
	}
	
	
	
	
	
	public static void clickRadioCurActual ()   {
		
		radioCurActual.click();
		
		
	}
	
	
	
	public static void clickBtnPrevMonth()  {
		
		btnPrevMonth.click();
		
		
		
	}
	
	
	
	
	public static String getSysdate()   {
		
		
		Calendar now = Calendar.getInstance();
		
		day  =  (now.get(Calendar.MONTH)+ 1);
		
		String d =String.valueOf(day);
		
		if (d.length()==1)
			
		{
			
		 sysdate = "0" + d + "/"
				+ now.get(Calendar.YEAR);
		
		}
		
		
		else {
			
			 sysdate =  d+ "/"
					+ now.get(Calendar.YEAR);
		}
		
		
		return sysdate;
		
		
	}
	
	
	public static void clickBtnUpdate()  {
		
		
		btnUpdate.click();
		
		
		
	}
	
	
	
	public static void clickBtnSaveMichsaYes()  {
		
		
		btnSaveMichsaYes.click();
		
		
		
	}
	
	
	
	
public static void clickbtnAcceptSuccess()  {
		
		
	btnAcceptSuccess.click();
		
		
		
	}
	
	
public static void clickBtnYes()  {
	
	
	btnYes.click();
		
		
		
	}



public static void clickBtnNo()  {


	btnNo.click();
	
	
	
}



public static void clickLblReset()  {


	lblReset.click();
	
	
	
}






public static void updateMichsa( String  value  )  {
	
	while (flag) {
        
		nametd = "tdMichsa" + h;
		eltd = Managment.clickMichsa(driver, nametd);
		if (eltd.getAttribute("class").equals("CellEditGrid") == true)

		{

			flag = false;
			eltd.click();
			//Managment.typeMichsa.sendKeys(value);
			Managment.typeMichsavalue(value);
			Managment.btnUpdate.click();
			Managment.btnSaveMichsaYes.click();
			Managment.btnAcceptSuccess.click();

		}

		h++;
	}
	
	
}
	


	public static void typeMichsaValues()  {
		
		int num=Managment.getNumOfRows();
		for (i = h; i < num; i++) {

			nametd = "tdMichsa" + i;
			eltd = Managment.clickMichsa(driver, nametd);
			if (eltd.getAttribute("class").equals("CellEditGrid") == true)

			{

				eltd.click();
				//Managment.typeMichsa.sendKeys(String.valueOf(michsa));
				Managment.typeMichsavalue(String.valueOf(michsa));
				michsa += 10;

			}

		}
		
		
		
	}
	
	
	
	
	public static void assertResetMichsa ()  {
		
		int num=getNumOfRows();
		
		
			for (i = 0; i < num; i++) {

		nametd = "tdMichsa" + i;
		eltd = Managment.clickMichsa(driver, nametd);
		if (eltd.getAttribute("class").equals("CellEditGrid") == true)

		{
			driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
			Assert.assertEquals(eltd.getText(), "0");
			System.out.println(eltd.getText());
		

		}

	}
		
		
		
		
		
	}
	
	
	
	public static void typeMichsavalue(String value1)  {
		
		
		typeMichsa.sendKeys(value1);
		
		
	}
	
	
	public static void clickbtnUnDo()  {
		
		
		btnUnDo.click();
		
		
	}
	
	
	
	
	public static String  typeMichsaOverBudget(String value) {
		
		
		while (num <10) {

			nametd = "tdMichsa" + i;
			eltd = Managment.clickMichsa(driver, nametd);

			if (eltd.getAttribute("class").equals("CellEditGrid") == true)

			{

				num = num + 1;
				driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

				

				eltd.click();
				//managment.typeMichsa.sendKeys("9999");
				Managment.typeMichsavalue(value);

			//	if (num == 1) {
			//		FirstTd = nametd;

			//	}
				

			}

			i++;
			
			
		

		}
		
		
		
		
		return nametd;
	
		
	}
	
	
	
	public static void clickBtnSaveMichsaNo ()  {
		
		
		
		btnSaveMichsaNo.click();
		
		
		
	}
	
	
	
	
	
	public static void assertUpdateMassageText()    {
		
		   try {
	        	
	        	System.out.println(Managment.updateMassage+"try");
	        	//System.out.println(element3.getText()+"try");
	        	Common.Wait_For_Element_Visibile(driver, 60, "dialog-grid", null, null);
	        	Managment.updateMassage.click();
	        	System.out.println(Managment.updateMassage.getText()+"try");
	        	Assert.assertEquals(Managment.updateMassage.getText(),"הנתונים נשמרו בהצלחה");
	        	
	        	
	        }
	        
	        catch (AssertionError e)  {
	        	
	    		Wait<WebDriver> wait = new WebDriverWait(driver, 10);

	    		// Wait for search to complete

	    		wait.until(new ExpectedCondition<Boolean>() {

	    			public Boolean apply(WebDriver webDriver) {

	    				System.out.println("Searching...");
	                    System.out.println(Managment.updateMassage.getText()+"catch");
	                    //System.out.println(return element3.getText()!="");
	    				return Managment.updateMassage.getText()!="";
	    				
	    				
	    			}

	    	
	             });
	    		
	    		
	    		Assert.assertEquals(Managment.updateMassage.getText(),"הנתונים נשמרו בהצלחה");
	    		
	        }
		
		
		
		
		
		
		
	}
	
	
	
	public static void  assertAutocompleteName() {
		
		
try {
			
			Assert.assertEquals(Managment.searchAutoComplete.getAttribute("value"),
					Managment.autoCompleteName.getText());
			
			
		}
		
		
		catch ( NoSuchElementException e  )  {
			
			
			Wait<WebDriver> wait = new WebDriverWait(driver, 10);
			wait.until( ExpectedConditions.presenceOfAllElementsLocatedBy(By.xpath("//tr[@class='clickable']//td[@id='tdName']")));
			Assert.assertEquals(Managment.searchAutoComplete.getAttribute("value"),
					Managment.autoCompleteName.getText());
			
			
			
		}
		
		
		
	}
	
	
	
	
	
	public static  int randomInteger(int min, int max) {
	    Random rand = new Random();
	    int randomNum = min + (int)(Math.random() * ((max - min) + 1));
	    return randomNum;
	}
	
	
	
	
	
	


	
	
	
	
	
	




	
	// public Budget(WebDriver driver) { 
	// this.driver=driver; }
	
	
	
	
}
