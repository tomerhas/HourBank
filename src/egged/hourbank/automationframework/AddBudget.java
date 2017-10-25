package egged.hourbank.automationframework;

import java.util.concurrent.TimeUnit;

import org.testng.Assert;
import org.testng.annotations.Test;
import org.testng.annotations.BeforeMethod;

import egged.hourbank.pageobjects.Mobility;
import egged.hourbank.utils.Base;
import egged.hourbank.utils.Common;

public class AddBudget  extends Base {
	
	
	
	
  @Test
  
  public void addBudget() {
	  
	  
	  driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
	  
	  enterMobility();
	  Mobility.clickAddBudget();	
	  Mobility.selectMitkan("91017");
	  Mobility.selectBudget("14");
	  Mobility.clickBtnUpdate();
	  Assert.assertEquals(Common.getDialogText(),"חובה לעדכן את כל השדות");
	  Common.clickAccept();
	  Mobility.typeKamut("250");
	  Mobility.typeReason("טסט");
	  Mobility.clickBtnUpdate();
	  Assert.assertEquals(Common.getDialogText(),"לא ניתן לעדכן מעבר ליתרה");
	  Common.clickAccept();
	  Mobility.selectBudget("13");
	  Mobility.typeKamut("1");
	  Mobility.clickBtnUpdate();
	  Common.Wait_For_Element_Visibile(driver, 60, "dialog-message", null, null);
	  Assert.assertEquals(Common.getDialogText(),"התקציב נוסף בהצלחה");
	  Common.clickAccept();
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
  }
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  @BeforeMethod
  public void beforeMethod() {
	  
	  driver = getDriver();
	  initMobility();
	  initCommon();
	  
	  
  }

}
