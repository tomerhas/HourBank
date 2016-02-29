package egged.hourbank.pageobjects;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;

public class Budget {
	
	
	 private static WebElement element;
	 
	 
	 
	 
	 
	/* public static WebElement btnShow (WebDriver driver) {                                    
			
			
			
			element=driver.findElement(By.id("btnShow"));
			
			return element;
		
		}*/
	
	 
	 
	 
	 
	 @FindBy(how=How.ID,using="btnShow")
	 
	 public  WebElement btnShow;
	 
	/* public static WebElement mitkanName (WebDriver driver) {                                    
			
			
			
			element=driver.findElement(By.id("MenuModel_MitkanName_KodYechida"));
			
			return element;
		
		}*/
	 
	 
	 
	 
	 
	 
	 @FindBy(how=How.ID,using="MenuModel_MitkanName_KodYechida")
	 
	 public  WebElement mitkanName;
	
	
	 
	 
	 public static WebElement btnUpdate (WebDriver driver) {                                    
			
			
			
			element=driver.findElement(By.id("btnUpdate"));
			
			return element;
		
		}
	 
	 
 @FindBy(how=How.ID,using="cancel")
	 
	 public  WebElement btnUnDo;
	 
	 
	 
	 
	 
	 
	 @FindBy(how=How.ID,using="btnYes")
	 
	 public  WebElement btnUnDoYes;
	 
	 
    @FindBy(how=How.ID,using="btnNo")
	 
	 public  WebElement btnUnDoNo;
	 
	 
    @FindBy(how=How.ID,using="btnYesSave")
	 
  	 public  WebElement btnSaveMichsaYes;
	 
	 
    @FindBy(how=How.ID,using="btnNoSave")
	 
  	 public  WebElement btnSaveMichsaNo;
    
    
    
    
    
    
    
    /*
	 
	 public static WebElement btnSaveMichsaYes (WebDriver driver) {                                    
			
			
			
			element=driver.findElement(By.id("btnYesSave"));
			
			return element;
		
		}
	 
	 
	 
	 
	 
	 public static WebElement btnSaveMichsaNo (WebDriver driver) {                                    
			
			
			
			element=driver.findElement(By.id("btnNoSave"));
			
			return element;
		
		}*/
	 
	 
	 
	 
	 
	 public static WebElement btnAccept (WebDriver driver) {                                    
			
			
			
			element=driver.findElement(By.id("okbtn"));
			
			return element;
		
		}
	 
	 
	 
	 
	 
	 public static WebElement btnAcceptSuccess (WebDriver driver) {                                    
			
			
			
			element=driver.findElement(By.id("btnGridOk"));
			
			return element;
		
		}
	 
	 

	
	 
	 

	 
	/* public static WebElement typeMichsa (WebDriver driver) {                                    
			
			
			
			element=driver.findElement(By.id("MichsaCur"));
			
			return element;
		
		}*/
	 
	 
	 
	 @FindBy(how=How.ID,using="MichsaCur")
	 
	 public WebElement typeMichsa;
	
	 

	 
	 

	 
	 
	 
	 
	 
	 
	 public static WebElement clickMichsa (WebDriver driver, String nametd) {                                    
			
		
		 
			element=driver.findElement(By.id(nametd));
			
			return element;
		
		}
	

	

	 

	 
	 
	 
	 
}
