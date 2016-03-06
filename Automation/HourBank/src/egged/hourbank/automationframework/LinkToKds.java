package egged.hourbank.automationframework;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.Select;
import org.testng.annotations.Test;
import org.testng.annotations.BeforeMethod;

import egged.hourbank.pageobjects.Budget;
import egged.hourbank.pageobjects.Main;
import egged.hourbank.utils.Base;

public class LinkToKds extends Base {
	
	
	public WebDriver driver;
	
	
	
	
  @Test
  public void f() {
	  
	    Main main = PageFactory.initElements(driver, Main.class);
		Budget budget = PageFactory.initElements(driver, Budget.class);
		driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
		main.lnkBudget.click();
		Select droplist = new Select(budget.mitkanName);
		droplist.selectByVisibleText("הנהלת מוסך נתניה");
		budget.btnShow.click();
		
		
	  
	  
	  
	  
  }
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  @BeforeMethod
  public void beforeMethod() {
	  
	  
	  driver=getDriver();
	  
	  
  }

}
