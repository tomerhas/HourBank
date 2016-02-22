package egged.hourbank.pageobjects;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

public class Budget {
	
	
	 private static WebElement element;
	 
	 
	 
	 
	 
	 public static WebElement btnShow (WebDriver driver) {                                    
			
			
			
			element=driver.findElement(By.id("btnShow"));
			
			return element;
		
		}
	
	 
	 
	 public static WebElement mitkanName (WebDriver driver) {                                    
			
			
			
			element=driver.findElement(By.id("MenuModel_MitkanName_KodYechida"));
			
			return element;
		
		}
	
	
	 
	 
	 public static WebElement btnUpdate (WebDriver driver) {                                    
			
			
			
			element=driver.findElement(By.id("btnUpdate"));
			
			return element;
		
		}
	 
	 
	 
	 public static WebElement btnSaveMichsaYes (WebDriver driver) {                                    
			
			
			
			element=driver.findElement(By.id("btnYesSave"));
			
			return element;
		
		}
	 
	 
	 
	 
	 
	 public static WebElement btnSaveMichsaNo (WebDriver driver) {                                    
			
			
			
			element=driver.findElement(By.id("btnNoSave"));
			
			return element;
		
		}
	 
	 
	 
	 
	 
	 public static WebElement btnAccept (WebDriver driver) {                                    
			
			
			
			element=driver.findElement(By.id("okbtn"));
			
			return element;
		
		}
	 
	 
	 
	 
	 
	 public static WebElement btnAcceptSuccess (WebDriver driver) {                                    
			
			
			
			element=driver.findElement(By.id("btnGridOk"));
			
			return element;
		
		}
	 
	 
	
	 public static WebElement clickMichsa1 (WebDriver driver) {                                    
			
			
			
			element=driver.findElement(By.id("tdMichsa1"));
			
			return element;
		
		}
	

	 
	 public static WebElement updateMichsa1 (WebDriver driver) {                                    
			
			
			
			element=driver.findElement(By.id("MichsaCur"));
			
			return element;
		
		}
	
	 
	 
	 
	 
	 
}
