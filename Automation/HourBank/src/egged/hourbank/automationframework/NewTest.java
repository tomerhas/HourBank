package egged.hourbank.automationframework;

import org.testng.Assert;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

import egged.hourbank.pageobjects.Managment;
import egged.hourbank.utils.Base;

public class NewTest extends Base{
	
	
	public WebDriver driver;
	
	
  @Test
  public void f() {
	  
	  
	  
	  enterNanagment();
	  //Managment.asserMitkanSelected("88486");
	  Assert.assertEquals(Managment.isMitkanSelected(), "88468");
	  
	 
	
	
	  
  }

	@BeforeMethod
	public void beforeMethod() {

		driver = getDriver();
		initBudget();

	}
  
  
  
 
  
  


}

