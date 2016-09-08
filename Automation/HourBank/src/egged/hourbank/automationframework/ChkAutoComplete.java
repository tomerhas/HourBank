package egged.hourbank.automationframework;

import org.openqa.selenium.Keys;
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
			Managment.searchAutoComplete.sendKeys(String.valueOf(lettter));

			Thread.sleep(300);
			

			String style = managment.listAutoComplete.getAttribute("style");

			System.out.println(managment.listAutoComplete.getAttribute("style"));

			if (style.contains("block"))

			{

				flag = false;
				Managment.searchAutoComplete.sendKeys(Keys.ARROW_DOWN);
				managment.itemMisparIshiSelected.click();
				System.out.println(Managment.searchAutoComplete.getAttribute("value"));
				
				

			}

			else {

				Managment.searchAutoComplete.clear();

			}
			i++;

		}
	
		
		
		
		Managment.clickAutoComplete();
		
	    //WebElement element1=driver.findElement(By.xpath("//tr[@class='clickable']//td[@id='tdName']"));
	    //System.out.println(element1.getText());
	    Assert.assertEquals(Managment.searchAutoComplete.getAttribute("value"),Managment.autoCompleteName.getText());
		
		//managment.searchAutoComplete.clear();
		//managment.searchAutoComplete.sendKeys("אאאא");
		Managment.typeAutoComplete("אאאא");
		Managment.clickAutoComplete();
		//WebElement element = driver.findElement(By.id("dialog-message"));
		Assert.assertEquals(managment.autoCompleteMessage.getText(),"מ.א/שם לא קיים למתקן זה");
		
		Managment.clickAccept();
		
		
		
	
		
	}
	
	
	
	
	
	
	
	
	@Test (priority=1) 
	public void chkAutoCompleteMispar() throws InterruptedException {

		enterNanagment();
		
		System.out.println(managment.listAutoComplete.getAttribute("style"));
		flag=true;
		j=1;
		while (flag) {

			Managment.searchAutoComplete.sendKeys(String.valueOf(j));

			Thread.sleep(300);
			

			String style = managment.listAutoComplete.getAttribute("style");

			System.out.println(managment.listAutoComplete.getAttribute("style"));

			if (style.contains("block"))

			{

				flag = false;
				Managment.searchAutoComplete.sendKeys(Keys.ARROW_DOWN);
				managment.itemMisparIshiSelected.click();
				System.out.println(Managment.searchAutoComplete.getAttribute("value"));
				
				

			}

			else {

				Managment.searchAutoComplete.clear();

			}
			j++;

		}
		
		
		
		Managment.clickAutoComplete();
		Assert.assertEquals(Managment.searchAutoComplete.getAttribute("value"),managment.highlightTr.getText().substring(0,5));
		System.out.println(managment.highlightTr.getText().substring(0,5));
		//managment.searchAutoComplete.clear();
		//managment.searchAutoComplete.sendKeys("0");
		Managment.typeAutoComplete("0");
		//managment.btnAutoComplete.click();
		Managment.clickAutoComplete();
		//WebElement element = driver.findElement(By.id("dialog-message"));
		Assert.assertEquals(managment.autoCompleteMessage.getText(),"מ.א/שם לא קיים למתקן זה");
		
		Managment.clickAccept();
		
		
		
		
		
		

	}

	@BeforeMethod
	public void beforeMethod() {

		driver = getDriver();
		initBudget();
	}

}
