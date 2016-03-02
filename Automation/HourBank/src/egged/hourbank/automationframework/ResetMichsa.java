package egged.hourbank.automationframework;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.Select;
import org.testng.Assert;
import org.testng.annotations.Test;
import org.testng.annotations.BeforeMethod;

import egged.hourbank.pageobjects.Budget;
import egged.hourbank.pageobjects.Main;
import egged.hourbank.utils.Base;

public class ResetMichsa  extends Base {
	
	public WebDriver driver;
	
	
	
  @Test
  public void f()   {
	  
	    String nametd;
		int i;
	    int michsa=40;
	  
	    
		    
		    
		Main main = PageFactory.initElements(driver, Main.class);
		Budget budget = PageFactory.initElements(driver, Budget.class);
		driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
		main.lnkBudget.click();
		Select droplist = new Select(budget.mitkanName);
		droplist.selectByVisibleText("הנהלת מוסך נתניה");
		budget.btnShow.click();
		
		    String symbol = "-";
		    int count = (driver.findElements(By.xpath("//tr[contains(@data-uid,'"+symbol+"')]")).size()) ;
		    System.out.println(count);
	
		
		
		for ( i=0;i<count;i++)    {
	    
			nametd = "tdMichsa" + i;
			WebElement eltd = Budget.clickMichsa(driver, nametd);
			if (eltd.getAttribute("class").equals("CellEditGrid") == true)
				
			{
		
				eltd.click();
				budget.typeMichsa.sendKeys(String.valueOf(michsa));
				michsa+=10;
			
	  
			}
	  
	  
			//eltd = Budget.clickMichsa(driver, nametd);
			 //System.out.println(eltd.getText());
		
	       
	
		
		}
		
		
		
	      budget.lblReset.click();
		   	WebElement element1 = driver.findElement(By
					.id("dialog-confirm"));
			Assert.assertEquals(element1.getText(),
					"עדכון זה יגרום לאיפוס השעות הנוספות שהוקצו לעובדים, האם לאפס?");
			budget.btnNo.click();
			budget.lblReset.click();
			WebElement element2 = driver.findElement(By
					.id("dialog-confirm"));
			Assert.assertEquals(element2.getText(),
					"עדכון זה יגרום לאיפוס השעות הנוספות שהוקצו לעובדים, האם לאפס?");
			budget.btnYes.click();
			
			System.out.println(budget.clickMichsa(driver,"tdMichsa1").getText());
			
		
		
		
		
		
		
		
		
		
  }
  
  
  
  

  
  @BeforeMethod
  public void beforeMethod() {
	  
	  
	  driver = getDriver();
	  
	  
	  
	  
	  
  }

}
