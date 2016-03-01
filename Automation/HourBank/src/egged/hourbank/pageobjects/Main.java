package egged.hourbank.pageobjects;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;

public class Main {

	// final WebDriver driver;

	@FindBy(how = How.LINK_TEXT, using = "ניהול תקציב")
	public WebElement lnkBudget;

	
	 //public Main(WebDriver driver) { 
	 //this.driver=driver; }
	 

}
