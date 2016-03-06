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

		String nametd = "";
		int num = 0;
		int i = 0;
		String FirstTd = "";
		WebElement eltd;
		
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
	

		while (num < 2) {

			nametd = "tdMichsa" + i;
			eltd = Budget.clickMichsa(driver, nametd);

			if (eltd.getAttribute("class").equals("CellEditGrid") == true)

			{

				num = num + 1;
				driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

				

				eltd.click();
				budget.typeMichsa.sendKeys("99999");

				if (num == 1) {
					FirstTd = nametd;

				}
				

			}

			i++;

		}

		budget.btnUpdate.click();
		WebElement element4 = driver.findElement(By.id("dialog-message"));
		System.out.println(element4.getText());
		Assert.assertEquals(element4.getText(),
				"�� ���� ���� �����: ��''� ������ ������� ���� ������ ����� �������");
		budget.btnAccept.click();
		
		eltd = Budget.clickMichsa(driver, FirstTd);
		eltd.click();
		budget.typeMichsa.sendKeys("0");
		
		eltd = Budget.clickMichsa(driver, nametd);
		eltd.click();
		budget.typeMichsa.sendKeys("30");
		budget.btnUpdate.click();
		WebElement element1 = driver.findElement(By.id("dialog-confirm"));
		Assert.assertEquals(element1.getText(),
				"����� �� ����� ������ ���� ������ �������, ��� �����?");
		budget.btnSaveMichsaNo.click();
		
		eltd.click();
		System.out.println(eltd);
		budget.typeMichsa.sendKeys("30");
		budget.btnUpdate.click();
		WebElement element2 = driver.findElement(By.id("dialog-confirm"));
		Assert.assertEquals(element2.getText(),
				"����� �� ����� ������ ���� ������ �������, ��� �����?");
		budget.btnSaveMichsaYes.click();
		
		WebElement element3 = driver.findElement(By.id("dialog-grid"));
		System.out.println(element3.getText());
		Assert.assertEquals(element3.getText(), "������� ����� ������");
		budget.btnAcceptSuccess.click();
		
		eltd = Budget.clickMichsa(driver, nametd);
		eltd.click();
		budget.typeMichsa.sendKeys("201");
		budget.btnUpdate.click();
		budget.btnSaveMichsaYes.click();
		WebElement element5 = driver.findElement(By.id("dialog-message"));
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

	@BeforeMethod
	public void beforeMethod() {
		driver = getDriver();

	}

}
