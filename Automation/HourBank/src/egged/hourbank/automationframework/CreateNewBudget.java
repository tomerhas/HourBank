package egged.hourbank.automationframework;

import java.sql.SQLException;
import java.util.concurrent.TimeUnit;

import org.testng.Assert;
import org.testng.annotations.Test;
import org.testng.annotations.BeforeMethod;

import egged.hourbank.jdbc.DbDml;
import egged.hourbank.pageobjects.Mobility;
import egged.hourbank.utils.Base;
import egged.hourbank.utils.Common;

public class CreateNewBudget extends Base {
  @Test
  public void createNewBudget() throws SQLException {
	  
	  driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
	  
	  DbDml.deleteRecordFromTable("'��������'");
	  enterMobility();
	  Mobility.clickAddBudget();
	  Mobility.clickCreateBudget();
	  Mobility.typeKamutNew("99999");
	  Mobility.typeBudgetName("��������");
	  Mobility.clickBtnUpdateBudget();
	  Assert.assertEquals(Common.getDialogText(),"���� ����� �� �� �����");
	  Common.clickAccept();
	  Mobility.typeReasonNew("���");
	  Mobility.clickBtnUpdateBudget();
	  Common.Wait_For_Element_Visibile(driver, 60, "dialog-message", null);
	  Assert.assertEquals(Common.getDialogText(),"������ ���� ������");
	  Common.clickAccept();
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
  }
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  @BeforeMethod
  public void beforeMethod() {
	  
	  driver = getDriver();
	  initMobility();
	  initCommon();
	  
	  
  }

}
