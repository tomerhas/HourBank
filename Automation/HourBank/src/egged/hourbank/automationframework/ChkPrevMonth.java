package egged.hourbank.automationframework;

import org.openqa.selenium.NoSuchElementException;
import org.testng.Assert;
import org.testng.annotations.Listeners;
import org.testng.annotations.Test;
import org.testng.annotations.BeforeMethod;
import egged.hourbank.pageobjects.Managment;
import egged.hourbank.utils.Base;


@Listeners({ egged.hourbank.listener.TestListener.class })
public class ChkPrevMonth extends Base {

	//public WebDriver driver;
	boolean exists;



	@Test
	public void chkPrevMonth() {

		enterNanagment();

		String date = managment.listDate.getAttribute("value");

		Assert.assertEquals(date.substring(3, 10),Managment.getSysdate());

		Assert.assertFalse(managment.btnNextMonth.isEnabled(),
				"btnNextMonth is enabled");

		Managment.clickBtnPrevMonth();

		Assert.assertTrue(managment.btnNextMonth.isEnabled(),
				"btnNextMonth is disabled");
		main.btnShow.click();

		try {
			exists=managment.daysLeft.isDisplayed();
			System.out.println(exists+"1");

		} catch (NoSuchElementException e) {
			exists = false;
			System.out.println(exists+"2");
		}

		if (exists == false) {
			System.out.println(exists+"3");
			Assert.assertFalse(managment.btnUpdate.isEnabled(),
					"btnUpdate is enabled");
			Assert.assertTrue(managment.lblResetDisabled.isDisplayed(),"lblReset is enabled");
			Assert.assertTrue(managment.lblAutoAllocationDisabled.isDisplayed(),"lblAutoAllocation is enabled");
			Assert.assertTrue(managment.btnUnDoDisabled.isDisplayed(),"btnUnDo is enabled");


		}

		if (exists == true) {
			System.out.println(exists+"4");
			Assert.assertTrue(managment.btnUpdate.isEnabled(),
					"btnUpdate is disabled");
			Assert.assertTrue(managment.btnUnDo.isEnabled(), "btnUnDo is disabled");
			Assert.assertTrue(managment.lblReset.isEnabled(),
					"lblReset is disabled");
			Assert.assertTrue(Managment.lblAutoAllocation.isEnabled(),
					"lblAutoAllocation is disabled");

		}

	}

	@BeforeMethod
	public void beforeMethod() {

		driver = getDriver();
		initBudget();

	}

}
