package egged.hourbank.automationframework;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.testng.Assert;
import org.testng.annotations.Listeners;
import org.testng.annotations.Test;
import org.testng.annotations.BeforeMethod;

import egged.hourbank.pageobjects.Managment;
import egged.hourbank.utils.Base;


@Listeners ({egged.hourbank.listener.TestListener.class})
public class ResetMichsa extends Base {

	public WebDriver driver;

	@Test
	public void resetMichsa() {

		String nametd;
		int i;
		int j = 0;
		boolean flag = true;
		int michsa = 40;
		WebElement eltd;

	
		
		driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
		
		
		enterNanagment();
		
		
		String symbol = "-";
		int count = (driver.findElements(By.xpath("//tr[contains(@data-uid,'"
				+ symbol + "')]")).size());
		System.out.println(count);

		while (flag) {

			nametd = "tdMichsa" + j;
			eltd = Managment.clickMichsa(driver, nametd);
			if (eltd.getAttribute("class").equals("CellEditGrid") == true)

			{

				flag = false;
				eltd.click();
				managment.typeMichsa.sendKeys("20");
				managment.btnUpdate.click();
				managment.btnSaveMichsaYes.click();
				managment.btnAcceptSuccess.click();

			}

			j++;
		}

		for (i = j; i < count; i++) {

			nametd = "tdMichsa" + i;
			eltd = Managment.clickMichsa(driver, nametd);
			if (eltd.getAttribute("class").equals("CellEditGrid") == true)

			{

				eltd.click();
				managment.typeMichsa.sendKeys(String.valueOf(michsa));
				michsa += 10;

			}

		}

		

		
		managment.lblReset.click();
		WebElement element1 = driver.findElement(By.id("dialog-confirm"));
		Assert.assertEquals(element1.getText(),
				"עדכון זה יגרום לאיפוס השעות הנוספות שהוקצו לעובדים, האם לאפס?");
		
		managment.btnNo.click();
		managment.lblReset.click();
		WebElement element2 = driver.findElement(By.id("dialog-confirm"));
		Assert.assertEquals(element2.getText(),
				"עדכון זה יגרום לאיפוס השעות הנוספות שהוקצו לעובדים, האם לאפס?");
		
		managment.btnYes.click();
		

		for (i = 0; i < count; i++) {

			nametd = "tdMichsa" + i;
			eltd = Managment.clickMichsa(driver, nametd);
			if (eltd.getAttribute("class").equals("CellEditGrid") == true)

			{
				driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
				Assert.assertEquals(eltd.getText(), "0");
				System.out.println(eltd.getText());
			

			}

		}
		
		
		managment.btnUpdate.click();
		managment.btnSaveMichsaYes.click();
		managment.btnAcceptSuccess.click();
		
		
		

	}

	@BeforeMethod
	public void beforeMethod() {

		driver = getDriver();
		initBudget();
	}

}
