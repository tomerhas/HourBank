package egged.hourbank.automationframework;

import java.util.concurrent.TimeUnit;

import org.testng.Assert;
import org.testng.annotations.Test;
import org.testng.annotations.BeforeMethod;

import egged.hourbank.utils.Base;
import egged.hourbank.utils.Common;

public class ChkMitkanInActive extends Base {
	
	
  @Test
  public void chkMitkanInActive () {
	  
	    driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
		enterNanagment("הנהלת מוסך דימונה");
		Assert.assertEquals(Common.getDialogText(),"לא נמצאו נתונים ליחידה והחודש הנבחר");
		Common.clickAccept();
	  
		
	  
  }
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  @BeforeMethod
  public void beforeMethod() {
	  
	  
	  driver = getDriver();
	  initCommon();
	  initBudget();
	  
  }

}
