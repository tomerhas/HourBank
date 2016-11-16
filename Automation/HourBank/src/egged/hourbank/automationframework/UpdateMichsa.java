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

		Assert.assertEquals(Common.getDialogText(),
				"לא בוצע שינוי במסך");
		Common.clickAccept();

		elementtd = Managment.typeMichsaOverBudget("9999");

		Managment.clickBtnUpdate();

		Assert.assertEquals(Common.getDialogText(),
				"לא ניתן לבצע שמירה: סה''כ המכסות שעודכנו גדול מתקציב השעות הנוספות");
		Common.clickAccept();

		Managment.clickLblReset();
		Managment.clickBtnYes();

		eltd = Managment.clickMichsa(driver, elementtd);
		eltd.click();
		Managment.typeMichsavalue("30");
		Managment.clickBtnUpdate();

		Assert.assertEquals(Managment.alertMassage.getText(),
				"עדכון זה יגרום לעדכון שעות נוספות לעובדים, האם לעדכן?");
		Managment.clickBtnSaveMichsaNo();
		Managment.clickBtnUpdate();

		Assert.assertEquals(Managment.alertMassage.getText(),
				"עדכון זה יגרום לעדכון שעות נוספות לעובדים, האם לעדכן?");

		Managment.clickBtnSaveMichsaYes();
		Managment.assertUpdateMassageText();

		Managment.clickbtnAcceptSuccess();
		eltd = Managment.clickMichsa(driver, elementtd);
		eltd.click();
		Managment.typeMichsavalue("201");
		Managment.clickBtnUpdate();
		Managment.clickBtnSaveMichsaYes();

		System.out.println(Common.getDialogText());
		Assert.assertEquals(Common.getDialogText(),
				"ארעה שגיאה בשמירת נתונים, אנא פנה למנהל מערכת");
		Common.clickAccept();

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
