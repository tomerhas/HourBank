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

@Listeners({ egged.hourbank.listener.TestListener.class })
public class UpdateMichsa extends Base {

	public WebDriver driver;

	@Test
	public void updateMichsa() {

		String elementtd;

		WebElement eltd;

		driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

		enterNanagment();

		Managment.clickBtnUpdate();

		Assert.assertEquals(Managment.dialogMessage.getText(),
				"�� ���� ����� ����");
		Managment.clickAccept();

		elementtd = Managment.typeMichsaOverBudget("9999");

		Managment.clickBtnUpdate();

		Assert.assertEquals(Managment.dialogMessage.getText(),
				"�� ���� ���� �����: ��''� ������ ������� ���� ������ ����� �������");
		Managment.clickAccept();

		Managment.clickLblReset();
		Managment.clickBtnYes();

		eltd = Managment.clickMichsa(driver, elementtd);
		eltd.click();
		Managment.typeMichsavalue("30");
		Managment.clickBtnUpdate();

		Assert.assertEquals(Managment.alertMassage.getText(),
				"����� �� ����� ������ ���� ������ �������, ��� �����?");
		Managment.clickBtnSaveMichsaNo();
		Managment.clickBtnUpdate();

		Assert.assertEquals(Managment.alertMassage.getText(),
				"����� �� ����� ������ ���� ������ �������, ��� �����?");

		Managment.clickBtnSaveMichsaYes();
		Managment.assertUpdateMassageText();

		Managment.clickbtnAcceptSuccess();
		eltd = Managment.clickMichsa(driver, elementtd);
		eltd.click();
		Managment.typeMichsavalue("201");
		Managment.clickBtnUpdate();
		Managment.clickBtnSaveMichsaYes();

		System.out.println(Managment.dialogMessage.getText());
		Assert.assertEquals(Managment.dialogMessage.getText(),
				"���� ����� ������ ������, ��� ��� ����� �����");
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
