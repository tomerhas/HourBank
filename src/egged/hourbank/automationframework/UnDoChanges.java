package egged.hourbank.automationframework;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.testng.Assert;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Listeners;
import org.testng.annotations.Test;

import egged.hourbank.pageobjects.Managment;
import egged.hourbank.utils.Base;
import egged.hourbank.utils.Common;


@Listeners ({egged.hourbank.listener.TestListener.class})
public class UnDoChanges extends Base {

	public WebDriver driver;

	@Test
	public void unDoChanges()  {

		String nametd;
		boolean flag = true;
		int i = 0;

		
		
		
		driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
		
		
		enterNanagment("הנהלת מוסך נתניה");

		while (flag) {

			nametd = "tdMichsa" + i;
			WebElement eltd = Managment.clickMichsa(driver, nametd);
			if (eltd.getAttribute("class").equals("CellEditGrid") == true)

			{

				flag = false;
				
				eltd.click();
				//Managment.typeMichsa.sendKeys("46.5");
				
				Managment.typeMichsavalue("46.5");
				Managment.clickbtnUnDo();
				//WebElement element1 = driver.findElement(By
						//.id("dialog-confirm"));
				
				Common.Wait_For_Element_Visibile(driver, 60, "dialog-confirm", null, null);
				Assert.assertEquals(Managment.alertMassage.getText(),
						"עדכון זה יגרום לביטול השעות שעדכנת כעת, האם לבטל שינויים?");
				Managment.clickBtnNo();
				Assert.assertEquals(eltd.getText(), "46.5");
				Managment.clickbtnUnDo();
				//WebElement element2 = driver.findElement(By
						//.id("dialog-confirm"));
				Common.Wait_For_Element_Visibile(driver, 60, "dialog-confirm", null, null);
				Assert.assertEquals(Managment.alertMassage.getText(),
						"עדכון זה יגרום לביטול השעות שעדכנת כעת, האם לבטל שינויים?");
				Managment.clickBtnYes();
				eltd = Managment.clickMichsa(driver, nametd);
				Assert.assertEquals(eltd.getText(), "0");

			}
			
			i++;

		}

	}

	@BeforeMethod
	public void beforeMethod() {

		driver = getDriver();
		initBudget();
	}

}
