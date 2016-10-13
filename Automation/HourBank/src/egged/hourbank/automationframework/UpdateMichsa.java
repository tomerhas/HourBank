package egged.hourbank.automationframework;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.ExpectedCondition;
import org.openqa.selenium.support.ui.Wait;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.testng.Assert;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Listeners;
import org.testng.annotations.Test;

import egged.hourbank.pageobjects.Managment;
import egged.hourbank.utils.Base;
import egged.hourbank.utils.Common;



@Listeners ({egged.hourbank.listener.TestListener.class})
public class UpdateMichsa extends Base {

	public WebDriver driver;

	@Test
	public void updateMichsa() {

		String nametd = "";
		//int num = 0;
		int i = 0;
		String FirstTd = "";
		WebElement eltd;
		
		
		
		driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

		
		enterNanagment();

		Managment.clickBtnUpdate();
		//WebElement element = driver.findElement(By.id("dialog-message"));
		//System.out.println(element.getText());
		Assert.assertEquals(Managment.dialogMessage.getText(), "�� ���� ����� ����");
		Managment.clickAccept();
		
        Managment.typeMichsaOverBudget("9999"); 
	/*	while (num <9) {

			nametd = "tdMichsa" + i;
			eltd = Managment.clickMichsa(driver, nametd);

			if (eltd.getAttribute("class").equals("CellEditGrid") == true)

			{

				num = num + 1;
				driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

				

				eltd.click();
				managment.typeMichsa.sendKeys("9999");

			//	if (num == 1) {
			//		FirstTd = nametd;

			//	}
				

			}

			i++;

		}*/

		Managment.clickBtnUpdate();
		//WebElement element4 = driver.findElement(By.id("dialog-message"));
		//System.out.println(element4.getText());
		Assert.assertEquals(Managment.dialogMessage.getText(),
				"�� ���� ���� �����: ��''� ������ ������� ���� ������ ����� �������");
		Managment.clickAccept();
		
		
		Managment.clickLblReset();
		managment.clickBtnYes();
		
		//eltd = Budget.clickMichsa(driver, FirstTd);
		//eltd.click();
		//budget.typeMichsa.sendKeys("0");
		
		eltd = Managment.clickMichsa(driver, nametd);
		eltd.click();
		managment.typeMichsavalue("30");
		managment.clickBtnUpdate();
		//WebElement element1 = driver.findElement(By.id("dialog-confirm"));
		Assert.assertEquals(Managment.alertMassage.getText(),
				"����� �� ����� ������ ���� ������ �������, ��� �����?");
		managment.clickBtnSaveMichsaNo();
		managment.clickBtnUpdate();
		//WebElement element2 = driver.findElement(By.id("dialog-confirm"));
		Assert.assertEquals(Managment.alertMassage.getText(),
				"����� �� ����� ������ ���� ������ �������, ��� �����?");
		
		managment.clickBtnSaveMichsaYes();
		
		
		
		WebElement element3 = driver.findElement(By.id("dialog-grid"));
		
        //System.out.println(element3.getText());
        try {
        	
        	System.out.println(element3+"try");
        	//System.out.println(element3.getText()+"try");
        	Common.Wait_For_Element_Visibile(driver, 60, "dialog-grid", null);
        	element3.click();
        	System.out.println(element3.getText()+"try");
        	Assert.assertEquals(element3.getText(),"������� ����� ������");
        	
        	
        }
        
        catch (AssertionError e)  {
        	
    		Wait<WebDriver> wait = new WebDriverWait(driver, 10);

    		// Wait for search to complete

    		wait.until(new ExpectedCondition<Boolean>() {

    			public Boolean apply(WebDriver webDriver) {

    				System.out.println("Searching...");
                    System.out.println(element3.getText()+"catch");
                    //System.out.println(return element3.getText()!="");
    				return element3.getText()!="";
    				
    				
    			}

    	
             });
    		
    		
    		Assert.assertEquals(element3.getText(),"������� ����� ������");
    		
        }
		
		managment.btnAcceptSuccess.click();
		eltd = Managment.clickMichsa(driver, nametd);
		eltd.click();
		managment.typeMichsa.sendKeys("201");
		managment.btnUpdate.click();
		managment.btnSaveMichsaYes.click();
		WebElement element5 = driver.findElement(By.id("dialog-message"));
		System.out.println(element5.getText());
		Assert.assertEquals(element5.getText(),
				"���� ����� ������ ������, ��� ��� ����� �����");
		managment.btnAccept.click();
		
		eltd = Managment.clickMichsa(driver, nametd);
		eltd.click();
		managment.typeMichsa.sendKeys("0");
		managment.btnUpdate.click();
		managment.btnSaveMichsaYes.click();
		managment.btnAcceptSuccess.click();

	}

	@BeforeMethod
	public void beforeMethod() {
		driver = getDriver();
		initBudget();

	}

}
