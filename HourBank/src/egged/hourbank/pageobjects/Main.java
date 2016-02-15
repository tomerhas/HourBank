package egged.hourbank.pageobjects;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

public class Main {
	
	 private static WebElement element;
	
	
	
	public static WebElement lnkBudget(WebDriver driver) {                                    
	
	
	
		element=driver.findElement(By.linkText("ניהול תקציב"));
		
		return element;
	
	}
	
	
	

}
