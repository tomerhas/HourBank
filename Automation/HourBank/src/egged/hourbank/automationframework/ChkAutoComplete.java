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
	int i;
	int j;

	
	
	
	@Test(priority=0)  
	
	
	public void chkAutoCompleteShem() throws InterruptedException {
		
	
		
		
	
		enterNanagment();
		
		String [] ArrayShem={"א","ב","ג","ד","ה","ו","ז","ח","ט ","י","כ","ל","מ" };
		i=0;
		
		
		System.out.println(managment.listAutoComplete.getAttribute("style"));
		
		while (flag&&i<=ArrayShem.length) {
			
			String lettter= ArrayShem[i];
			managment.searchAutoComplete.sendKeys(String.valueOf(lettter));

			Thread.sleep(300);
			

			String style = managment.listAutoComplete.getAttribute("style");

			System.out.println(managment.listAutoComplete.getAttribute("style"));

			if (style.contains("block"))

			{

				flag = false;
				managment.searchAutoComplete.sendKeys(Keys.ARROW_DOWN);
				managment.itemMisparIshiSelected.click();
				System.out.println(managment.searchAutoComplete.getAttribute("value"));
				
				

			}

			else {

				managment.searchAutoComplete.clear();

			}
			i++;

		}
	
		
		
		
		managment.btnAutoComplete.click();
		
	    WebElement element1=driver.findElement(By.xpath("//tr[@class='clickable']//td[@id='tdName']"));
	    System.out.println(element1.getText());
	    Assert.assertEquals(managment.searchAutoComplete.getAttribute("value"),element1.getText());
		
		managment.searchAutoComplete.clear();
		managment.searchAutoComplete.sendKeys("אאאא");
		managment.btnAutoComplete.click();
		WebElement element = driver.findElement(By.id("dialog-message"));
		Assert.assertEquals(element.getText(),"מ.א/שם לא קיים למתקן זה");
		managment.btnAccept.click();
		
		
		
		
		
		
		
		
		
		
	}
	
	
	
	
	
	
	
	
	
	
	
	
	@Test (priority=1) 
	public void chkAutoCompleteMispar() throws InterruptedException {

		enterNanagment();
		
		System.out.println(managment.listAutoComplete.getAttribute("style"));
		flag=true;
		j=1;
		while (flag) {

			managment.searchAutoComplete.sendKeys(String.valueOf(j));

			Thread.sleep(300);
			

			String style = managment.listAutoComplete.getAttribute("style");

			System.out.println(managment.listAutoComplete.getAttribute("style"));

			if (style.contains("block"))

			{

				flag = false;
				managment.searchAutoComplete.sendKeys(Keys.ARROW_DOWN);
				managment.itemMisparIshiSelected.click();
				System.out.println(managment.searchAutoComplete.getAttribute("value"));
				
				

			}

			else {

				managment.searchAutoComplete.clear();

			}
			j++;

		}
		
		
		
		managment.btnAutoComplete.click();
		Assert.assertEquals(managment.searchAutoComplete.getAttribute("value"),managment.highlightTr.getText().substring(0,5));
		System.out.println(managment.highlightTr.getText().substring(0,5));
		managment.searchAutoComplete.clear();
		managment.searchAutoComplete.sendKeys("0");
		managment.btnAutoComplete.click();
		WebElement element = driver.findElement(By.id("dialog-message"));
		Assert.assertEquals(element.getText(),"מ.א/שם לא קיים למתקן זה");
		managment.btnAccept.click();
		
		
		
		
		
		

	}

	@BeforeMethod
	public void beforeMethod() {

		driver = getDriver();
		initBudget();
	}

}
