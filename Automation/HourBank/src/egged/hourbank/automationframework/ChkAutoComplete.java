package egged.hourbank.automationframework;

import org.openqa.selenium.WebDriver;
import org.testng.Assert;
import org.testng.annotations.Listeners;
import org.testng.annotations.Test;
import org.testng.annotations.BeforeMethod;
import egged.hourbank.pageobjects.Managment;
import egged.hourbank.utils.Base;



@Listeners({ egged.hourbank.listener.TestListener.class })
public class ChkAutoComplete extends Base {

	public WebDriver driver;

	@Test(priority = 0)
	public void chkAutoCompleteShem() throws InterruptedException {

		enterNanagment();
		Managment.setNameAutocomplete();
		Managment.clickAutoComplete();
		Assert.assertEquals(Managment.searchAutoComplete.getAttribute("value"),
				Managment.autoCompleteName.getText());
		Managment.typeAutoComplete("אאאא");
		Managment.clickAutoComplete();
		Assert.assertEquals(managment.autoCompleteMessage.getText(),
				"מ.א/שם לא קיים למתקן זה");
		Managment.clickAccept();

	}

	
	
	@Test(priority = 1)
	public void chkAutoCompleteMispar() throws InterruptedException {

		enterNanagment();
		Managment.setMisparishiAutocomplete();
		Managment.clickAutoComplete();
		Assert.assertEquals(Managment.searchAutoComplete.getAttribute("value"),
				managment.highlightTr.getText().substring(0, 5));
		Managment.typeAutoComplete("0");
		Managment.clickAutoComplete();
		Assert.assertEquals(managment.autoCompleteMessage.getText(),
				"מ.א/שם לא קיים למתקן זה");
		Managment.clickAccept();
	}

	
	
	@BeforeMethod
	public void beforeMethod() {

		driver = getDriver();
		initBudget();
	}

}
