package egged.hourbank.pageobjects;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;

public class Budget {

	private static WebElement element;

	@FindBy(how = How.ID, using = "btnShow")
	public WebElement btnShow;

	@FindBy(how = How.ID, using = "MenuModel_MitkanName_KodYechida")
	public WebElement mitkanName;

	@FindBy(how = How.ID, using = "btnUpdate")
	public WebElement btnUpdate;

	@FindBy(how = How.ID, using = "cancel")
	public WebElement btnUnDo;

	@FindBy(how = How.ID, using = "btnYes")
	public WebElement btnUnDoYes;

	@FindBy(how = How.ID, using = "btnNo")
	public WebElement btnUnDoNo;

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

	public static WebElement clickMichsa(WebDriver driver, String nametd) {

		element = driver.findElement(By.id(nametd));

		return element;

	}

}
