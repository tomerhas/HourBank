package egged.hourbank.pageobjects;

import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;

public  class Main {

	// final WebDriver driver;

	@FindBy(how = How.LINK_TEXT, using = "����� �����")
	public  WebElement lnkBudget;
	
	
	@FindBy(how = How.LINK_TEXT, using = "���� �����")
	public  WebElement lnkMobility;
	
	
	@FindBy(how = How.ID, using = "btnShow")
	public WebElement btnShow;
	

	
	 //public Main(WebDriver driver) { 
	 //this.driver=driver; }
	 

}
