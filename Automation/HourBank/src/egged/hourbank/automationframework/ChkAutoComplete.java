package egged.hourbank.automationframework;

import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.testng.Assert;
import org.testng.annotations.Listeners;
import org.testng.annotations.Test;
import org.testng.annotations.BeforeMethod;
import egged.hourbank.utils.Base;

@Listeners({ egged.hourbank.listener.TestListener.class })
public class ChkAutoComplete extends Base {

	public WebDriver driver;
	boolean flag = true;
	int i =1;

	@Test
	public void chkAutoComplete() throws InterruptedException {

		enterBudget();
		
		System.out.println(budget.listAutoComplete.getAttribute("style"));
		
		while (flag) {

			budget.searchAutoComplete.sendKeys(String.valueOf(i));

			Thread.sleep(300);
			

			String style = budget.listAutoComplete.getAttribute("style");

			System.out.println(budget.listAutoComplete.getAttribute("style"));

			if (style.contains("block"))

			{

				flag = false;
				budget.searchAutoComplete.sendKeys(Keys.ARROW_DOWN);
				budget.itemMisparIshiSelected.click();
				System.out.println(budget.searchAutoComplete.getAttribute("value"));
				
				

			}

			else {

				budget.searchAutoComplete.clear();

			}
			i++;

		}
		
		
		
		budget.btnAutoComplete.click();
		Assert.assertEquals(budget.searchAutoComplete.getAttribute("value"),budget.highlightTr.getText().substring(0,5));
		System.out.println(budget.highlightTr.getText().substring(0,5));
		budget.searchAutoComplete.clear();
		budget.searchAutoComplete.sendKeys("0");
		budget.btnAutoComplete.click();
		WebElement element = driver.findElement(By.id("dialog-message"));
		Assert.assertEquals(element.getText(),"מ.א/שם זה לא קיים למתקן זה");
		budget.btnAccept.click();
		
		
		
		
		

	}

	@BeforeMethod
	public void beforeMethod() {

		driver = getDriver();
		initBudget();
	}

}
