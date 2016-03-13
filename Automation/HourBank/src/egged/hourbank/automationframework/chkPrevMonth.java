package egged.hourbank.automationframework;

import org.openqa.selenium.WebDriver;
import org.testng.annotations.Test;
import org.testng.annotations.BeforeMethod;

import egged.hourbank.utils.Base;

public class chkPrevMonth extends Base {
	
	
	public WebDriver driver;
	
	
	
	
	
  @Test
  public void f() {
	  
	  System.out.println(budget.daysLeft.isDisplayed());
	  
  }
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  @BeforeMethod
  public void beforeMethod() {
	  
		driver = getDriver();
		initBudget();
	  
	  
  }

}
