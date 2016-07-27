package egged.hourbank.automationframework;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.ExpectedCondition;
import org.openqa.selenium.support.ui.Wait;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.testng.Assert;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Listeners;
import org.testng.annotations.Test;

import egged.hourbank.pageobjects.Managment;
import egged.hourbank.utils.Base;
import egged.hourbank.utils.Common;



@Listeners ({egged.hourbank.listener.TestListener.class})
public class UpdateMichsa extends Base {

	public WebDriver driver;

	@Test
	public void updateMichsa() {

		String nametd = "";
		int num = 0;
		int i = 0;
		String FirstTd = "";
		WebElement eltd;
		
		
		
		driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

		
		enterBudget();

		budget.btnUpdate.click();
		WebElement element = driver.findElement(By.id("dialog-message"));
		System.out.println(element.getText());
		Assert.assertEquals(element.getText(), "לא בוצע שינוי במסך");
		budget.btnAccept.click();
		

		while (num <5) {

			nametd = "tdMichsa" + i;
			eltd = Managment.clickMichsa(driver, nametd);

			if (eltd.getAttribute("class").equals("CellEditGrid") == true)

			{

				num = num + 1;
				driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

				

				eltd.click();
				budget.typeMichsa.sendKeys("9999");

			//	if (num == 1) {
			//		FirstTd = nametd;

			//	}
				

			}

			i++;

		}

		budget.btnUpdate.click();
		WebElement element4 = driver.findElement(By.id("dialog-message"));
		System.out.println(element4.getText());
		Assert.assertEquals(element4.getText(),
				"לא ניתן לבצע שמירה: סה''כ המכסות שעודכנו גדול מתקציב השעות הנוספות");
		budget.btnAccept.click();
		
		
		budget.lblReset.click();
		budget.btnYes.click();
		
		//eltd = Budget.clickMichsa(driver, FirstTd);
		//eltd.click();
		//budget.typeMichsa.sendKeys("0");
		
		eltd = Managment.clickMichsa(driver, nametd);
		eltd.click();
		budget.typeMichsa.sendKeys("30");
		budget.btnUpdate.click();
		WebElement element1 = driver.findElement(By.id("dialog-confirm"));
		Assert.assertEquals(element1.getText(),
				"עדכון זה יגרום לעדכון שעות נוספות לעובדים, האם לעדכן?");
		budget.btnSaveMichsaNo.click();
		budget.btnUpdate.click();
		WebElement element2 = driver.findElement(By.id("dialog-confirm"));
		Assert.assertEquals(element2.getText(),
				"עדכון זה יגרום לעדכון שעות נוספות לעובדים, האם לעדכן?");
		
		budget.btnSaveMichsaYes.click();
		
		
		
		WebElement element3 = driver.findElement(By.id("dialog-grid"));
		
        //System.out.println(element3.getText());
        try {
        	
        	System.out.println(element3+"try");
        	//System.out.println(element3.getText()+"try");
        	Common.Wait_For_Element_Visibile(driver, 60, "dialog-grid", null);
        	element3.click();
        	System.out.println(element3.getText()+"try");
        	Assert.assertEquals(element3.getText(),"הנתונים נשמרו בהצלחה");
        	
        	
        }
        
        catch (AssertionError e)  {
        	
    		Wait<WebDriver> wait = new WebDriverWait(driver, 10);

    		// Wait for search to complete

    		wait.until(new ExpectedCondition<Boolean>() {

    			public Boolean apply(WebDriver webDriver) {

    				System.out.println("Searching...");
                    System.out.println(element3.getText()+"catch");
                    //System.out.println(return element3.getText()!="");
    				return element3.getText()!="";
    				
    				
    			}

    	
             });
    		
    		
    		Assert.assertEquals(element3.getText(),"הנתונים נשמרו בהצלחה");
    		
        }
		
		budget.btnAcceptSuccess.click();
		eltd = Managment.clickMichsa(driver, nametd);
		eltd.click();
		budget.typeMichsa.sendKeys("201");
		budget.btnUpdate.click();
		budget.btnSaveMichsaYes.click();
		WebElement element5 = driver.findElement(By.id("dialog-message"));
		System.out.println(element5.getText());
		Assert.assertEquals(element5.getText(),
				"ארעה שגיאה בשמירת נתונים, אנא פנה למנהל מערכת");
		budget.btnAccept.click();
		
		eltd = Managment.clickMichsa(driver, nametd);
		eltd.click();
		budget.typeMichsa.sendKeys("0");
		budget.btnUpdate.click();
		budget.btnSaveMichsaYes.click();
		budget.btnAcceptSuccess.click();

	}

	@BeforeMethod
	public void beforeMethod() {
		driver = getDriver();
		initBudget();

	}

}
