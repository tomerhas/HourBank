package egged.hourbank.automationframework;
import org.openqa.selenium.WebDriver;
import org.testng.annotations.Test;
import org.testng.annotations.BeforeMethod;

import egged.hourbank.pageobjects.Main;
import egged.hourbank.utils.Base;



public class NewTest  extends Base  {
	
	public  WebDriver driver;
	
	
  @Test
  public void f() {
	  
	  Main.lnkBudget(driver).click();
	  
	  
	  
	  
	  
	  
  }
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  @BeforeMethod
  public void beforeMethod() {
	  driver=getDriver();
	  
  }

}
