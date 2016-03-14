package egged.hourbank.automationframework;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.testng.Assert;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Listeners;
import org.testng.annotations.Test;

import egged.hourbank.pageobjects.Budget;
import egged.hourbank.utils.Base;


@Listeners ({egged.hourbank.listener.TestListener.class})
public class UnDoChanges extends Base {

	public WebDriver driver;

	@Test
	public void unDoChanges() {

		String nametd;
		boolean flag = true;
		int i = 0;

		
		
		
		driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
		
		
		enterBudget();

		while (flag) {

			nametd = "tdMichsa" + i;
			WebElement eltd = Budget.clickMichsa(driver, nametd);
			if (eltd.getAttribute("class").equals("CellEditGrid") == true)

			{

				flag = false;
				driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
				eltd.click();
				budget.typeMichsa.sendKeys("46.5");
				budget.btnUnDo.click();
				WebElement element1 = driver.findElement(By
						.id("dialog-confirm"));
				Assert.assertEquals(element1.getText(),
						"עדכון זה יגרום לביטול השעות שעדכנת כעת, האם לבטל שינויים?");
				budget.btnNo.click();
				Assert.assertEquals(eltd.getText(), "46.5");
				budget.btnUnDo.click();
				WebElement element2 = driver.findElement(By
						.id("dialog-confirm"));
				Assert.assertEquals(element2.getText(),
						"עדכון זה יגרום לביטול השעות שעדכנת כעת, האם לבטל שינויים?");
				budget.btnYes.click();
				eltd = Budget.clickMichsa(driver, nametd);
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
