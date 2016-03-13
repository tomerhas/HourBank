package egged.hourbank.automationframework;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.testng.Assert;
import org.testng.annotations.Listeners;
import org.testng.annotations.Test;
import org.testng.annotations.BeforeMethod;

import egged.hourbank.pageobjects.Budget;
import egged.hourbank.utils.Base;




@Listeners ({egged.hourbank.listener.TestListener.class})
public class AutoAllocation extends Base {
	
	public WebDriver driver;
	int i;
	int j;
	WebElement eltd;
	WebElement plantd;
	WebElement actualtd;
	String nametd;
	String actualtdname;
	String plantdname;
	
	
	
	
  @Test (priority=0)
  public void autoAllocationPlan() {
	  
	  driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
		
		
		enterBudget();
		budget.lblAutoAllocation.click();
		budget.radioPrevPlan.click();
		budget.btnAutoAllocation.click();
		
		
		String symbol = "-";
		int count = (driver.findElements(By.xpath("//tr[contains(@data-uid,'"
				+ symbol + "')]")).size());
		System.out.println(count);
		
		
		for (i=0;i<count-1;i++) {
			
			nametd = "tdMichsa" + i;
			eltd = Budget.clickMichsa(driver,nametd);
			plantdname =  "tdPrevMonth" + i;
			plantd = Budget.clickMichsa(driver,plantdname);
			if (eltd.getAttribute("class").equals("CellEditGrid") == true)
				
				
				
			{
			
				System.out.println(eltd.getText()+"הקצאת שעות");
				System.out.println(plantd.getText()+"הקצאה לחודש קודם");
				Assert.assertEquals(eltd.getText(), plantd.getText());
			
		}
			
		}
		
	//	WebElement element = driver.findElement(By.id("tdPrevMonth4"));
	//	System.out.println(element.getText());
		
	//	WebElement element1 = driver.findElement(By.id("tdMichsa4"));
		//System.out.println(element1.getText());
	

	  
  }
  
  
  
  
	
	
  @Test  (priority=1)
  public void autoAllocationActual() {
	  
	  driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
		
		
		enterBudget();
		budget.lblAutoAllocation.click();
		budget.radioCurActual.click();
		budget.btnAutoAllocation.click();
		
		
		String symbol = "-";
		int count = (driver.findElements(By.xpath("//tr[contains(@data-uid,'"
				+ symbol + "')]")).size());
		System.out.println(count);
		
		
		for (i=0;i<count-1;i++) {
			
			nametd = "tdMichsa" + i;
			eltd = Budget.clickMichsa(driver,nametd);
			actualtdname =  "tdShaotUsed" + i;
			actualtd = Budget.clickMichsa(driver,actualtdname);
			if (eltd.getAttribute("class").equals("CellEditGrid") == true)
				
				
				
			{
			
				System.out.println(eltd.getText());
				System.out.println(actualtd.getText());
				Assert.assertEquals(eltd.getText(), actualtd.getText());
			
		}
			
		}
		
	//	WebElement element = driver.findElement(By.id("tdPrevMonth4"));
	//	System.out.println(element.getText());
		
	//	WebElement element1 = driver.findElement(By.id("tdMichsa4"));
		//System.out.println(element1.getText());
	

	  
  }
  
  
  
  
  
  
  
  
  
  
  
  @BeforeMethod
  public void beforeMethod() {
	  
		driver = getDriver();
		initBudget();
	  
	  
	  
	  
  }

}
