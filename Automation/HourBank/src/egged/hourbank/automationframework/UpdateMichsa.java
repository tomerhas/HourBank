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
		droplist.selectByVisibleText("����� ���� �����");
		budget.btnShow.click();
		budget.btnUpdate.click();
		WebElement element = driver.findElement(By.id("dialog-message"));
		System.out.println(element.getText());
		Assert.assertEquals(element.getText(), "�� ���� ����� ����");
		budget.btnAccept.click();
		// Assert.assertTrue(Budget.clickMichsa1(driver).getAttribute("class").equals("CellEditGrid")==true);
		// System.out.println(Budget.clickMichsa1(driver).getAttribute("class").equals("CellEditGrid"));

		while (flag) {

			nametd = "tdMichsa" + i;

			WebElement eltd = Budget.clickMichsa(driver, nametd);

			if (eltd.getAttribute("class").equals("CellEditGrid") == true)

			{

				flag = false;
				driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
				eltd.click();
				budget.typeMichsa.sendKeys("30");
				budget.btnUpdate.click();
				WebElement element1 = driver.findElement(By
						.id("dialog-confirm"));
				Assert.assertEquals(element1.getText(),
						"����� �� ����� ������ ���� ������ �������, ��� �����?");
				budget.btnSaveMichsaNo.click();
				eltd.click();
				System.out.println(eltd);
				budget.typeMichsa.sendKeys("30");
				budget.btnUpdate.click();
				WebElement element2 = driver.findElement(By
						.id("dialog-confirm"));
				Assert.assertEquals(element2.getText(),
						"����� �� ����� ������ ���� ������ �������, ��� �����?");
				budget.btnSaveMichsaYes.click();
				WebElement element3 = driver.findElement(By.id("dialog-grid"));
				System.out.println(element3.getText());
				Assert.assertEquals(element3.getText(), "������� ����� ������");
				budget.btnAcceptSuccess.click();
				budget.btnShow.click();
				System.out.println(eltd);
				eltd = Budget.clickMichsa(driver, nametd);

				eltd.click();
				budget.typeMichsa.sendKeys("99999");
				budget.btnUpdate.click();
				WebElement element4 = driver.findElement(By
						.id("dialog-message"));
				System.out.println(element4.getText());
				Assert.assertEquals(element4.getText(),
						"�� ���� ���� �����: ��''� ������ ������� ���� ������ ����� �������");
				budget.btnAccept.click();

				eltd.click();
				budget.typeMichsa.sendKeys("201");
				budget.btnUpdate.click();
				budget.btnSaveMichsaYes.click();
				WebElement element5 = driver.findElement(By
						.id("dialog-message"));
				System.out.println(element5.getText());
				Assert.assertEquals(element5.getText(),
						"���� ����� ������ ������, ��� ��� ����� �����");
				budget.btnAccept.click();
				eltd = Budget.clickMichsa(driver, nametd);
				eltd.click();
				budget.typeMichsa.sendKeys("0");
				budget.btnUpdate.click();
				budget.btnSaveMichsaYes.click();
				budget.btnAcceptSuccess.click();

			}

			i++;

		}

	}

	@BeforeMethod
	public void beforeMethod() {
		driver = getDriver();

	}

}
