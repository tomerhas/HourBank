package egged.hourbank.automationframework;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.Select;
import org.testng.Assert;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

import egged.hourbank.pageobjects.Budget;
import egged.hourbank.pageobjects.Main;
import egged.hourbank.utils.Base;

public class UpdateMichsa extends Base {

	public WebDriver driver;

	@Test
	public void f() {

		String nametd;
		boolean flag = true;
		int i = 0;

		Main main = PageFactory.initElements(driver, Main.class);
		Budget budget = PageFactory.initElements(driver, Budget.class);
		driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

		main.lnkBudget.click();

		Select droplist = new Select(budget.mitkanName);
		droplist.selectByVisibleText("הנהלת מוסך נתניה");
		budget.btnShow.click();
		Budget.btnUpdate(driver).click();
		WebElement element = driver.findElement(By.id("dialog-message"));
		System.out.println(element.getText());
		Assert.assertEquals(element.getText(), "לא בוצע שינוי במסך");
		Budget.btnAccept(driver).click();
		// Assert.assertTrue(Budget.clickMichsa1(driver).getAttribute("class").equals("CellEditGrid")==true);
		// System.out.println(Budget.clickMichsa1(driver).getAttribute("class").equals("CellEditGrid"));

		/*
		 * Budget.clickMichsa1(driver).click();
		 * Budget.typeMichsa.sendKeys("30");
		 * Budget.btnUpdate(driver).click(); WebElement
		 * element2=driver.findElement(By.id("dialog-confirm"));
		 * Assert.assertEquals(element2.getText(),
		 * "עדכון זה יגרום לעדכון שעות נוספות לעובדים, האם לעדכן?");
		 * Budget.btnSaveMichsaYes(driver).click(); WebElement
		 * element3=driver.findElement(By.id("dialog-grid"));
		 * System.out.println(element3.getText());
		 * Assert.assertEquals(element3.getText(),"הנתונים נשמרו בהצלחה");
		 * Budget.btnAcceptSuccess(driver).click();
		 * Budget.btnShow(driver).click(); Budget.clickMichsa1(driver).click();
		 * Budget.typeMichsa.sendKeys("99999");
		 */

		while (flag) {

			nametd = "tdMichsa" + i;
			// WebElement eltd=budget.
			WebElement eltd = Budget.clickMichsa(driver, nametd);
			// eltd.click();
			if (eltd.getAttribute("class").equals("CellEditGrid") == true)

			{

				flag = false;
				driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
				eltd.click();
				budget.typeMichsa.sendKeys("30");
				Budget.btnUpdate(driver).click();
				WebElement element1 = driver.findElement(By
						.id("dialog-confirm"));
				Assert.assertEquals(element1.getText(),
						"עדכון זה יגרום לעדכון שעות נוספות לעובדים, האם לעדכן?");
				budget.btnSaveMichsaNo.click();
				eltd.click();
				System.out.println(eltd);
				budget.typeMichsa.sendKeys("30");
				Budget.btnUpdate(driver).click();
				WebElement element2 = driver.findElement(By
						.id("dialog-confirm"));
				Assert.assertEquals(element2.getText(),
						"עדכון זה יגרום לעדכון שעות נוספות לעובדים, האם לעדכן?");
				budget.btnSaveMichsaYes.click();
				WebElement element3 = driver.findElement(By.id("dialog-grid"));
				System.out.println(element3.getText());
				Assert.assertEquals(element3.getText(), "הנתונים נשמרו בהצלחה");
				Budget.btnAcceptSuccess(driver).click();
				budget.btnShow.click();
				System.out.println(eltd);
				// WebDriverWait wait = new WebDriverWait(driver,120);
				// wait.until(ExpectedConditions.stalenessOf((eltd)));
				// WebDriverWait wait1 = new WebDriverWait(driver,50);
				// wait1.until(ExpectedConditions.visibilityOf(eltd));
				// WebDriverWait wait = new WebDriverWait(driver,20);
				// wait.until(ExpectedConditions.visibilityOfElementLocated((eltd)));
				eltd = Budget.clickMichsa(driver, nametd);
				eltd.click();
				// Budget.clickMichsa1(driver).click();
				budget.typeMichsa.sendKeys("99999");
				Budget.btnUpdate(driver).click();
				WebElement element4 = driver.findElement(By
						.id("dialog-message"));
				System.out.println(element4.getText());
				Assert.assertEquals(element4.getText(),
						"לא ניתן לבצע שמירה: סה''כ המכסות שעודכנו גדול מתקציב השעות הנוספות");
				Budget.btnAccept(driver).click();
				eltd.click();
				budget.typeMichsa.sendKeys("201");
				Budget.btnUpdate(driver).click();
				budget.btnSaveMichsaYes.click();
				WebElement element5 = driver.findElement(By
						.id("dialog-message"));
				System.out.println(element5.getText());
				Assert.assertEquals(element5.getText(),
						"ארעה שגיאה בשמירת נתונים, אנא פנה למנהל מערכת");
				Budget.btnAccept(driver).click();
				eltd = Budget.clickMichsa(driver, nametd);
				eltd.click();
				budget.typeMichsa.sendKeys("0");
				Budget.btnUpdate(driver).click();
				budget.btnSaveMichsaYes.click();
				Budget.btnAcceptSuccess(driver).click();

			}

			i++;

		}

	}

	@BeforeMethod
	public void beforeMethod() {
		driver = getDriver();

	}

}
