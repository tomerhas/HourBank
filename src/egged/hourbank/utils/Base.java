package egged.hourbank.utils;


import java.io.File;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebDriverException;
import org.openqa.selenium.ie.InternetExplorerDriver;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.Select;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;

import egged.hourbank.pageobjects.Managment;
import egged.hourbank.pageobjects.Main;
import egged.hourbank.pageobjects.Mobility;

public abstract  class Base {
	
	
	
	
	
	

protected static WebDriver driver;
public Main main ;
public Managment managment ;
public Mobility mobility  ; 
public Common common ;


public WebDriver getDriver() {
    return driver;
}




public void initBudget()
{
	managment = PageFactory.initElements(driver, Managment.class);
}



public void initMobility()
{
	mobility = PageFactory.initElements(driver,Mobility.class);
}



public void initCommon()
{
	common = PageFactory.initElements(driver,Common.class);
}








@BeforeMethod
public  void createDriver() {
	
	File file = new File("C:/Selenium/IEDriverServer.exe");
	System.setProperty("webdriver.ie.driver", file.getAbsolutePath());
	DesiredCapabilities cap = new DesiredCapabilities();
	cap.setCapability(InternetExplorerDriver.IE_ENSURE_CLEAN_SESSION, true);
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
	
	

public    void enterNanagment (String mitkanname)    {
	
	
	main.lnkBudget.click();
	Select droplist = new Select(managment.mitkanName);
	droplist.selectByVisibleText(mitkanname);
	main.btnShow.click();
	
	
}




public void enterMobility ()    {
	
	main.lnkMobility.click();
	//Select droplist = new Select(Mobility.listEzor);
	//droplist.selectByVisibleText("דרום");
	main.btnShow.click();
	
	
	
	
	
}









}




	
	
	
	
	
	
	
