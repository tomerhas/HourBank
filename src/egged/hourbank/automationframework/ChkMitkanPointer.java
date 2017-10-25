package egged.hourbank.automationframework;



import java.util.concurrent.TimeUnit;

import org.testng.Assert;
import org.testng.annotations.Test;
import org.testng.annotations.BeforeMethod;

import egged.hourbank.pageobjects.Mobility;
import egged.hourbank.utils.Base;
import egged.hourbank.utils.Common;

public class ChkMitkanPointer extends Base {
  @Test
  public void chkMitkanPointer() {
	  
	    driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
	    enterMobility();
	    Mobility.moveToPointer();
	    Common.Wait_For_Element_Visibile(driver, 60, null, null, "//*[@id='buttons']//div/label[.='הוסף']");
	    Mobility.clickPointer(Mobility.addBudgetPointer);
		Assert.assertEquals(Common.getActualText(Mobility.getTextSelected(Mobility.listMitkanInAdd), "\\("),Common.getActualText(Mobility.firstmitkanName.getText(),"הוסף")+" ");
		Mobility.closeDialog();
		Mobility.moveToPointer();
		Common.Wait_For_Element_Visibile(driver, 60, null, null, "//*[@id='buttons']//div/label[.='נייד']");
		Mobility.clickPointer(Mobility.mobileBudgetPointer);
		Assert.assertEquals(Common.getActualText(Mobility.getTextSelected(Mobility.listMitkanInMobile), "\\("),Common.getActualText(Mobility.firstmitkanName.getText(),"הוסף")+" ");
		    
		
		
	  
	  
  }
  
  
  
  
  
  @BeforeMethod
  public void beforeMethod() {
	  
	  driver = getDriver();
	  initMobility();
	  
	  
  }

}
