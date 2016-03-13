package egged.hourbank.automationframework;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.WebDriver;
import org.testng.Assert;
import org.testng.annotations.Listeners;
import org.testng.annotations.Test;
import org.testng.annotations.BeforeMethod;

import egged.hourbank.utils.Base;
import egged.hourbank.utils.Common;


@Listeners ({egged.hourbank.listener.TestListener.class})
public class LinkToKds extends Base {

	public WebDriver driver;

	@Test
	public void linkToKds() {

		

		driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

		enterBudget();
		budget.lnkKds.click();
		Common a = new Common();
		a.waitForWindow("Nochechut", driver);
		driver.manage().window().maximize();
		Assert.assertEquals(budget.KdsHeader.getText(), "נוכחות מרוכזת");
		System.out.println(budget.KdsHeader.getText());

		
	}

	@BeforeMethod
	public void beforeMethod() {

		driver = getDriver();
		initBudget();

	}

}
