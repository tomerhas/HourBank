package egged.hourbank.automationframework;
import java.util.concurrent.TimeUnit;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.Select;
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
	  WebElement element=driver.findElement(By.id("dialog-message"));
	  System.out.println(element.getText());
	  Assert.assertEquals(element.getText(),"לא בוצע שינוי במסך");
	  Budget.btnAccept(driver).click();
	  Budget.clickMichsa1(driver).click();
	  Budget.updateMichsa1(driver).sendKeys("30");
	  Budget.btnUpdate(driver).click();
	  WebElement element1=driver.findElement(By.id("dialog-confirm"));
	  Assert.assertEquals(element1.getText(),"עדכון זה יגרום לעדכון שעות נוספות לעובדים, האם לעדכן?");
	  Budget.btnSaveMichsaNo(driver).click();
	  Budget.clickMichsa1(driver).click();
	  Budget.updateMichsa1(driver).sendKeys("30");
	  Budget.btnUpdate(driver).click();
	  WebElement element2=driver.findElement(By.id("dialog-confirm"));
	  Assert.assertEquals(element2.getText(),"עדכון זה יגרום לעדכון שעות נוספות לעובדים, האם לעדכן?");
	  Budget.btnSaveMichsaYes(driver).click();
	  WebElement element3=driver.findElement(By.id("dialog-grid"));
	  System.out.println(element3.getText());
	  Assert.assertEquals(element3.getText(),"הנתונים נשמרו בהצלחה");
	  Budget.btnAcceptSuccess(driver).click();
	  Budget.clickMichsa1(driver).click();
	  Budget.updateMichsa1(driver).sendKeys("99999");
	  Budget.btnUpdate(driver).click();
	  WebElement element4=driver.findElement(By.id("dialog-message"));
	  System.out.println(element4.getText());
	  Assert.assertEquals(element4.getText(),"לא ניתן לבצע שמירה: סה''כ המכסות שעודכנו גדול מתקציב השעות הנוספות");
	  Budget.btnAccept(driver).click();
	  Budget.clickMichsa1(driver).click();
	  Budget.updateMichsa1(driver).sendKeys("201");
	  Budget.btnUpdate(driver).click();
	  Budget.btnSaveMichsaYes(driver).click();
	  WebElement element5=driver.findElement(By.id("dialog-message"));
	  System.out.println(element5.getText());
	  Assert.assertEquals(element5.getText(),"ארעה שגיאה בשמירת נתונים, אנא פנה למנהל מערכת");
	  Budget.btnAccept(driver).click();
	  Budget.clickMichsa1(driver).click();
	  Budget.updateMichsa1(driver).sendKeys("0");
	  Budget.btnUpdate(driver).click();
	  Budget.btnSaveMichsaYes(driver).click();
	  Budget.btnAcceptSuccess(driver).click();
	  
	  
	  
	  
	  
	  
	  
	 
	  
	  
	  
	  
	  
	  
  }
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  @BeforeMethod
  public void beforeMethod() {
	  driver=getDriver();
	  
  }

}
