package egged.hourbank.automationframework;

import java.util.concurrent.TimeUnit;

import org.testng.annotations.Listeners;
import org.testng.annotations.Test;
import org.testng.annotations.BeforeMethod;

import egged.hourbank.pageobjects.Managment;
import egged.hourbank.utils.Base;




@Listeners ({egged.hourbank.listener.TestListener.class})
public class AutoAllocation extends Base {
	
	
	//public WebDriver driver;
	int i;
	int j;

	
	
	
	
	
	
  @Test (priority=0)
  public void autoAllocationPlan() {
	  
	  driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
		
		
		enterNanagment();
		Managment.clicklblAutoAllocation();
		Managment.clickradioPrevPlan();
		Managment.clickbtnAutoAllocation();
		Managment.assertPlanTd();
		

	  
  }
  
  
  
  
	
	
  @Test  (priority=1)
  public void autoAllocationActual() {
	  
	  driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
		
		
		enterNanagment();
		Managment.clicklblAutoAllocation();
		Managment.clickRadioCurActual();
		Managment.clickbtnAutoAllocation();
		Managment.assertActualTd();
		


	  
  }
  
  
  
 
  
  
  
  @BeforeMethod
  public void beforeMethod() {
	  
		driver = getDriver();
		initBudget();
	  
	  
	  
	  
  }

}
