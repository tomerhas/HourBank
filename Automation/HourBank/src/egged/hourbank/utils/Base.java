package egged.hourbank.utils;


import java.io.File;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebDriverException;
import org.openqa.selenium.ie.InternetExplorerDriver;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.Select;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;

import egged.hourbank.pageobjects.Budget;
import egged.hourbank.pageobjects.Main;

public abstract  class Base {
	
	
	
	
	
	

private WebDriver driver;
public Main main ;
public Budget budget ;

public WebDriver getDriver() {
    return driver;
}




public void initBudget()
{
	  budget = PageFactory.initElements(driver, Budget.class);
}


@BeforeMethod
public  void createDriver() {
	
	File file = new File("C:/Selenium/IEDriverServer.exe");
	System.setProperty("webdriver.ie.driver", file.getAbsolutePath());
	 driver = new InternetExplorerDriver();
	  driver.navigate().to("http://bsm");
	  main = PageFactory.initElements(driver, Main.class);
}
	






@AfterMethod
public void tearDownDriver() {
    if (driver != null){
        try{
            driver.quit();
        }
        catch (WebDriverException e) {
            System.out.println("***** CAUGHT EXCEPTION IN DRIVER TEARDOWN *****");
            System.out.println(e);
        }
    }
}
	
	

public   void enterBudget ()    {
	
	
	main.lnkBudget.click();
	Select droplist = new Select(budget.mitkanName);
	droplist.selectByVisibleText("הנהלת מוסך נתניה");
	budget.btnShow.click();
	
	
}









}




	
	
	
	
	
	
	
