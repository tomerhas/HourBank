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

		String elementtd;
		//String nametd="";
		//int num = 0;
		int i = 0;
		//String FirstTd = "";
		WebElement eltd;
		
		
		
		driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

		
		enterNanagment();

		Managment.clickBtnUpdate();
		//WebElement element = driver.findElement(By.id("dialog-message"));
		//System.out.println(element.getText());
		Assert.assertEquals(Managment.dialogMessage.getText(), "לא בוצע שינוי במסך");
		Managment.clickAccept();
		
		elementtd=Managment.typeMichsaOverBudget("9999"); 
	/*	while (num <9) {

			nametd = "tdMichsa" + i;
			eltd = Managment.clickMichsa(driver, nametd);

			if (eltd.getAttribute("class").equals("CellEditGrid") == true)

			{

				num = num + 1;
				driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

				

				eltd.click();
				managment.typeMichsa.sendKeys("9999");

			//	if (num == 1) {
			//		FirstTd = nametd;

			//	}
				

			}

			i++;

		}*/

		Managment.clickBtnUpdate();
		//WebElement element4 = driver.findElement(By.id("dialog-message"));
		//System.out.println(element4.getText());
		Assert.assertEquals(Managment.dialogMessage.getText(),
				"לא ניתן לבצע שמירה: סה''כ המכסות שעודכנו גדול מתקציב השעות הנוספות");
		Managment.clickAccept();
		
		
		Managment.clickLblReset();
		Managment.clickBtnYes();
		
		//eltd = Budget.clickMichsa(driver, FirstTd);
		//eltd.click();
		//budget.typeMichsa.sendKeys("0");
		
		eltd = Managment.clickMichsa(driver, elementtd);
		eltd.click();
		Managment.typeMichsavalue("30");
		Managment.clickBtnUpdate();
		//WebElement element1 = driver.findElement(By.id("dialog-confirm"));
		Assert.assertEquals(Managment.alertMassage.getText(),
				"עדכון זה יגרום לעדכון שעות נוספות לעובדים, האם לעדכן?");
		Managment.clickBtnSaveMichsaNo();
		Managment.clickBtnUpdate();
		//WebElement element2 = driver.findElement(By.id("dialog-confirm"));
		Assert.assertEquals(Managment.alertMassage.getText(),
				"עדכון זה יגרום לעדכון שעות נוספות לעובדים, האם לעדכן?");
		
		Managment.clickBtnSaveMichsaYes();
		
		
		
		//WebElement element3 = driver.findElement(By.id("dialog-grid"));
		
        //System.out.println(element3.getText());
        try {
        	
        	System.out.println(Managment.updateMassage+"try");
        	//System.out.println(element3.getText()+"try");
        	Common.Wait_For_Element_Visibile(driver, 60, "dialog-grid", null);
        	Managment.updateMassage.click();
        	System.out.println(Managment.updateMassage.getText()+"try");
        	Assert.assertEquals(Managment.updateMassage.getText(),"הנתונים נשמרו בהצלחה");
        	
        	
        }
        
        catch (AssertionError e)  {
        	
    		Wait<WebDriver> wait = new WebDriverWait(driver, 10);

    		// Wait for search to complete

    		wait.until(new ExpectedCondition<Boolean>() {

    			public Boolean apply(WebDriver webDriver) {

    				System.out.println("Searching...");
                    System.out.println(Managment.updateMassage.getText()+"catch");
                    //System.out.println(return element3.getText()!="");
    				return Managment.updateMassage.getText()!="";
    				
    				
    			}

    	
             });
    		
    		
    		Assert.assertEquals(Managment.updateMassage.getText(),"הנתונים נשמרו בהצלחה");
    		
        }
		
		Managment.clickbtnAcceptSuccess();
		eltd = Managment.clickMichsa(driver, elementtd);
		eltd.click();
		Managment.typeMichsavalue("201");
		Managment.clickBtnUpdate();
		Managment.clickBtnSaveMichsaYes();
		//WebElement element5 = driver.findElement(By.id("dialog-message"));
		System.out.println(Managment.dialogMessage.getText());
		Assert.assertEquals(Managment.dialogMessage.getText(),
				"ארעה שגיאה בשמירת נתונים, אנא פנה למנהל מערכת");
		Managment.clickAccept();
		
		eltd = Managment.clickMichsa(driver, elementtd);
		eltd.click();
		Managment.typeMichsavalue("0");
		Managment.clickBtnUpdate();
		Managment.clickBtnSaveMichsaYes();
		Managment.clickbtnAcceptSuccess();

	}

	@BeforeMethod
	public void beforeMethod() {
		driver = getDriver();
		initBudget();

	}

}
