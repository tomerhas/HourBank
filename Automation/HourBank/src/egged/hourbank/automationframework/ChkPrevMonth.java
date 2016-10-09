package egged.hourbank.automationframework;

import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebDriver;
import org.testng.Assert;
import org.testng.annotations.Listeners;
import org.testng.annotations.Test;
import org.testng.annotations.BeforeMethod;

import sun.security.util.Length;

import java.util.Calendar;

import egged.hourbank.utils.Base;


@Listeners({ egged.hourbank.listener.TestListener.class })
public class ChkPrevMonth extends Base {

	//public WebDriver driver;
	boolean exists;
	int day;
	String sysdate ;
	

	@Test
	public void chkPrevMonth() {

		enterNanagment();
		 
		
	
		Calendar now = Calendar.getInstance();
		
		day  =  (now.get(Calendar.MONTH)+ 1);
		
		String d =String.valueOf(day);
		
		if (d.length()==1)
			
		{
			
		 sysdate = "0" + d + "/"
				+ now.get(Calendar.YEAR);
		
		}
		
		
		else {
			
			 sysdate =  d+ "/"
					+ now.get(Calendar.YEAR);
		}
		
		String date = managment.listDate.getAttribute("value");
		
		Assert.assertEquals(date.substring(3, 10),sysdate);
		
		Assert.assertFalse(managment.btnNextMonth.isEnabled(),
				"btnNextMonth is enabled");
		managment.btnPrevMonth.click();
		Assert.assertTrue(managment.btnNextMonth.isEnabled(),
				"btnNextMonth is disabled");
		managment.btnShow.click();

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
			Assert.assertTrue(managment.lblAutoAllocation.isEnabled(),
					"lblAutoAllocation is disabled");

		}

	}

	@BeforeMethod
	public void beforeMethod() {

		driver = getDriver();
		initBudget();

	}

}
