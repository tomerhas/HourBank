package egged.hourbank.utils;


import java.io.File;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebDriverException;
import org.openqa.selenium.ie.InternetExplorerDriver;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.Select;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;

import egged.hourbank.pageobjects.Managment;
import egged.hourbank.pageobjects.Main;

public abstract  class Base {
	
	
	
	
	
	

private WebDriver driver;
public Main main ;
public Managment managment ;

public WebDriver getDriver() {
    return driver;
}




public void initBudget()
{
	managment = PageFactory.initElements(driver, Managment.class);
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
	
	

public   void enterNanagment ()    {
	
	
	main.lnkBudget.click();
	Select droplist = new Select(managment.mitkanName);
	droplist.selectByVisibleText("הנהלת מוסך נתניה");
	managment.btnShow.click();
	
	
}









}




	
	
	
	
	
	
	
