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

	@FindBy(how = How.ID, using = "cancel")
	public WebElement btnUnDo;

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
	
	@FindBy(how = How.ID, using = "rbTichnunPrev")
	public WebElement radioPrevPlan;
	
	@FindBy(how = How.ID, using = "rbBizuaPrev")
	public WebElement radioPrevActual;
	
	@FindBy(how = How.ID, using = "rbTichnunCur")
	public WebElement radioCurActual;
	
	
	
	
	
	
	
	
	
	

	public static WebElement clickMichsa(WebDriver driver, String nametd) {

		element = driver.findElement(By.id(nametd));

		return element;

	}

	
	// public Budget(WebDriver driver) { 
	// this.driver=driver; }
	
	
	
	
}
