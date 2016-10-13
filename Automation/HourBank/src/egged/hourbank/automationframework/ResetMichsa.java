package egged.hourbank.automationframework;

import java.util.concurrent.TimeUnit;
import org.testng.Assert;
import org.testng.annotations.Listeners;
import org.testng.annotations.Test;
import org.testng.annotations.BeforeMethod;
import egged.hourbank.pageobjects.Managment;
import egged.hourbank.utils.Base;

@Listeners({ egged.hourbank.listener.TestListener.class })
public class ResetMichsa extends Base {

	// public WebDriver driver;

	@Test
	public void resetMichsa() {

		// int num=Managment.getNumOfRows();

		driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

		enterNanagment();

		Managment.updateMichsa("20");

		System.out.println(Managment.getNumOfRows());
		Managment.typeMichsaValues();

		Managment.clickLblReset();

		Assert.assertEquals(Managment.alertMassage.getText(),
				"עדכון זה יגרום לאיפוס השעות הנוספות שהוקצו לעובדים, האם לאפס?");

		Managment.clickBtnNo();
		Managment.clickLblReset();

		Assert.assertEquals(Managment.alertMassage.getText(),
				"עדכון זה יגרום לאיפוס השעות הנוספות שהוקצו לעובדים, האם לאפס?");

		Managment.clickBtnYes();

		Managment.assertResetMichsa();

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
