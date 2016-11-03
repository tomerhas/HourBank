package egged.hourbank.automationframework;

import java.util.Random;
import java.util.stream.IntStream;

import org.testng.Assert;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.Select;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

import egged.hourbank.pageobjects.Managment;
import egged.hourbank.utils.Base;

public class NewTest extends Base{
	
	
	public WebDriver driver;
	int i;
	String nametd;
	static WebElement eltd;
	int sum=0;
	
	
	
  @Test
  public void f() {
	  
	  
	  
	  enterNanagment();
	  
	  //Assert.assertEquals(Managment.isMitkanSelected(), "88468");
	  
	  int num=Managment.getNumOfRows();
	  Select droplist = new Select(managment.mitkanName);
		droplist.selectByVisibleText("הנהלת מוסך אשקלון");
		managment.btnShow.click();
		
		
		
	/*	for (i=0;i<num;i++)    {
			
			nametd = "tdMichsa" + i;
			eltd=Managment.clickMichsa(driver, nametd);
			
			int michsa=Integer.valueOf(eltd.getText()); 
			
			String smichsa = Integer.toString(michsa+2);
			
			if (michsa<10 && eltd.getAttribute("class").equals("CellEditGrid") == true)   {
				
				eltd.click();
				Managment.typeMichsavalue(smichsa);
				
				
				
			}
			
			
			
			
			
		}*/
		
	
		
		
		/*	for (i=0;i<num;i++)    {
				
				nametd = "tdMichsa" + i;
				eltd=Managment.clickMichsa(driver, nametd);
				
				int michsa=Managment.randomInteger(1, 10);
				
			if (eltd.getAttribute("class").equals("CellEditGrid") == true)  {
				
				
				sum=sum+michsa;
				
			}
			
			else {
				
				sum=sum+0;
				
			}
				
			    System.out.println("random="+michsa);
				System.out.println(sum);
				
				String smichsa = Integer.toString(michsa);
				
				if (sum<20 && eltd.getAttribute("class").equals("CellEditGrid") == true)   {
					
					eltd.click();
					Managment.typeMichsavalue(smichsa);
					//System.out.println(eltd.getText());
					
					
					
				}
				
				
				
				
				
			}*/
		
		
		
		
		
		
		
		
		
		
		
		
	  
	 
	  
	 
	
	
	  
  }

	@BeforeMethod
	public void beforeMethod() {

		driver = getDriver();
		initBudget();

	}
  
  
  
 
  
  


}

