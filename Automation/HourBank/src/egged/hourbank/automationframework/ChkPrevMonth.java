package egged.hourbank.automationframework;

import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebDriver;
import org.testng.Assert;
import org.testng.annotations.Listeners;
import org.testng.annotations.Test;
import org.testng.annotations.BeforeMethod;
import java.util.Calendar;
import egged.hourbank.utils.Base;


@Listeners({ egged.hourbank.listener.TestListener.class })
public class ChkPrevMonth extends Base {

	public WebDriver driver;
	boolean exists;

	@Test
	public void chkPrevMonth() {

		enterBudget();
		 
		
	
		Calendar now = Calendar.getInstance();
		String sysdate = "0" + (now.get(Calendar.MONTH) + 1) + "/"
				+ now.get(Calendar.YEAR);
		String date = budget.listDate.getAttribute("value");
		Assert.assertEquals(date.substring(3, 10),sysdate);
		
		Assert.assertFalse(budget.btnNextMonth.isEnabled(),
				"btnNextMonth is enabled");
		budget.btnPrevMonth.click();
		Assert.assertTrue(budget.btnNextMonth.isEnabled(),
				"btnNextMonth is disabled");
		budget.btnShow.click();

		try {
			exists=budget.daysLeft.isDisplayed();
			System.out.println(exists+"1");
			
		} catch (NoSuchElementException e) {
			exists = false;
			System.out.println(exists+"2");
		}

		if (exists == false) {
			System.out.println(exists+"3");
			Assert.assertFalse(budget.btnUpdate.isEnabled(),
					"btnUpdate is enabled");
			Assert.assertTrue(budget.lblResetDisabled.isDisplayed(),"lblReset is enabled");
			Assert.assertTrue(budget.lblAutoAllocationDisabled.isDisplayed(),"lblAutoAllocation is enabled");
			Assert.assertTrue(budget.btnUnDoDisabled.isDisplayed(),"btnUnDo is enabled");
			

		}

		if (exists == true) {
            System.out.println(exists+"4");
			Assert.assertTrue(budget.btnUpdate.isEnabled(),
					"btnUpdate is disabled");
			Assert.assertTrue(budget.btnUnDo.isEnabled(), "btnUnDo is disabled");
			Assert.assertTrue(budget.lblReset.isEnabled(),
					"lblReset is disabled");
			Assert.assertTrue(budget.lblAutoAllocation.isEnabled(),
					"lblAutoAllocation is disabled");

		}

	}

	@BeforeMethod
	public void beforeMethod() {

		driver = getDriver();
		initBudget();

	}

}
