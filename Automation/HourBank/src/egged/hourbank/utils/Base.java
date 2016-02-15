package egged.hourbank.utils;


import java.io.File;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebDriverException;
import org.openqa.selenium.ie.InternetExplorerDriver;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;

public abstract  class Base {
	
	
	
	
	
	

private WebDriver driver;

public WebDriver getDriver() {
    return driver;
}






@BeforeMethod
public  void createDriver() {
	
	File file = new File("C:/Selenium/IEDriverServer.exe");
	System.setProperty("webdriver.ie.driver", file.getAbsolutePath());
	 driver = new InternetExplorerDriver();
	  driver.navigate().to("http://bsm");
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
	
	
}
	
	
	
	
	
	
	
