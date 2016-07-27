package egged.hourbank.automationframework;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.testng.Assert;
import org.testng.annotations.Listeners;
import org.testng.annotations.Test;
import org.testng.annotations.BeforeMethod;

import egged.hourbank.pageobjects.Managment;
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
		
		
		enterNanagment();
		managment.lblAutoAllocation.click();
		managment.radioPrevPlan.click();
		managment.btnAutoAllocation.click();
		
		
		String symbol = "-";
		int count = (driver.findElements(By.xpath("//tr[contains(@data-uid,'"
				+ symbol + "')]")).size());
		System.out.println(count);
		
		
		for (i=0;i<count-1;i++) {
			
			nametd = "tdMichsa" + i;
			eltd = Managment.clickMichsa(driver,nametd);
			plantdname =  "tdPrevMonth" + i;
			plantd = Managment.clickMichsa(driver,plantdname);
			if (eltd.getAttribute("class").equals("CellEditGrid") == true)
				
				
				
			{
			
				System.out.println(eltd.getText()+"הקצאת שעות");
				System.out.println(plantd.getText()+"הקצאה לחודש קודם");
				Assert.assertEquals(eltd.getText(), plantd.getText());
			
		}
			
		}
		

	

	  
  }
  
  
  
  
	
	
  @Test  (priority=1)
  public void autoAllocationActual() {
	  
	  driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
		
		
		enterNanagment();
		managment.lblAutoAllocation.click();
		managment.radioCurActual.click();
		managment.btnAutoAllocation.click();
		
		
		String symbol = "-";
		int count = (driver.findElements(By.xpath("//tr[contains(@data-uid,'"
				+ symbol + "')]")).size());
		System.out.println(count);
		
		
		for (i=0;i<count-1;i++) {
			
			nametd = "tdMichsa" + i;
			eltd = Managment.clickMichsa(driver,nametd);
			actualtdname =  "tdShaotUsed" + i;
			actualtd = Managment.clickMichsa(driver,actualtdname);
			if (eltd.getAttribute("class").equals("CellEditGrid") == true)
				
				
				
			{
			
				System.out.println(eltd.getText());
				System.out.println(actualtd.getText());
				Assert.assertEquals(eltd.getText(), actualtd.getText());
			
		}
			
		}
		
	
	

	  
  }
  
  
  
  
  
  
  
  
  
  
  
  @BeforeMethod
  public void beforeMethod() {
	  
		driver = getDriver();
		initBudget();
	  
	  
	  
	  
  }

}
