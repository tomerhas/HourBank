package egged.hourbank.pageobjects;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;

public  class Budget {

	private static WebElement element;
	//final WebDriver driver;

	@FindBy(how = How.ID, using = "btnShow")
	public WebElement btnShow;

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
	public WebElement btnAccept;

	@FindBy(how = How.ID, using = "btnGridOk")
	public WebElement btnAcceptSuccess;

	@FindBy(how = How.ID, using = "MichsaCur")
	public WebElement typeMichsa;
	
	@FindBy(how = How.ID, using = "tdKds0")
	public WebElement lnkKds;
	
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
	public WebElement searchAutoComplete;
	
	@FindBy(how = How.CLASS_NAME, using = "SearchBG")
	public WebElement btnAutoComplete;
	
	@FindBy(how = How.ID, using = "MisparIshi-list")
	public WebElement listAutoComplete;
	
	@FindBy(how = How.ID, using = "k-item")
	public WebElement itemMisparIshi;
	
	@FindBy(how = How.ID, using = "MisparIshi_option_selected")
	public WebElement itemMisparIshiSelected;
	
	@FindBy(how = How.CLASS_NAME, using = "clickable")
	public WebElement highlightTr ;
	
	
	
	
	
	
	
	
	
	
	
	
	

	public static WebElement clickMichsa(WebDriver driver, String elname) {

		element = driver.findElement(By.id(elname));

		return element;

	}

	
	// public Budget(WebDriver driver) { 
	// this.driver=driver; }
	
	
	
	
}
