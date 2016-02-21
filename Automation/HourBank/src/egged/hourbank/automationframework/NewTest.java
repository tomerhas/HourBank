package egged.hourbank.automationframework;
import java.util.concurrent.TimeUnit;
import org.openqa.selenium.Alert;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.Select;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.testng.Assert;
import org.testng.annotations.Test;
import org.testng.annotations.BeforeMethod;

import egged.hourbank.pageobjects.Budget;
import egged.hourbank.pageobjects.Main;
import egged.hourbank.utils.Base;



public class NewTest  extends Base  {
	
	public  WebDriver driver;
	
	
  @Test
  public void f() {
	  driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
	  Main.lnkBudget(driver).click();
      Select droplist = new Select(Budget.mitkanName(driver));
      droplist.selectByVisibleText("הנהלת מוסך נתניה");
	  Budget.btnShow(driver).click();
	  Budget.btnUpdate(driver).click();
	  Budget.accsept(driver).click();
	  //WebDriverWait wait = new WebDriverWait(driver, 30);
      //wait.until(ExpectedConditions.alertIsPresent());
	  //Alert alert=driver.switchTo().alert();
	  //Assert.assertEquals("לא בוצע שינוי במסך",alert.getText());
	  //alert.accept();
	  Budget.clickMichsa1(driver).click();
	  Budget.updatMichsaUpdate1(driver).sendKeys("30");
	  
	 
	  
	  
	  
	  
	  
	  
  }
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  @BeforeMethod
  public void beforeMethod() {
	  driver=getDriver();
	  
  }

}
