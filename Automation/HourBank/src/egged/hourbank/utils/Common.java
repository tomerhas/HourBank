package egged.hourbank.utils;

import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.ElementNotVisibleException;
import org.openqa.selenium.StaleElementReferenceException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.FluentWait;
import org.openqa.selenium.support.ui.WebDriverWait;

import com.google.common.base.Function;

public class Common {
	
	
	private static WebElement element;
	
	 
	 public static WebElement Wait_For_Element_Visibile(final WebDriver driver, final int timeoutSeconds,String snameId) {
		    FluentWait<WebDriver> wait = new FluentWait<WebDriver>(driver)
		    		
		            .withTimeout(timeoutSeconds, TimeUnit.SECONDS)
		            .pollingEvery(500, TimeUnit.MILLISECONDS)
		            .ignoring(StaleElementReferenceException.class,ElementNotVisibleException.class);
		            
		    return wait.until(new Function<WebDriver, WebElement>() {
		        public WebElement apply(WebDriver webDriver) {
		        	WebDriverWait wait = new WebDriverWait(driver,50);
		        	wait.until(ExpectedConditions.visibilityOf(driver.findElement(By.id(snameId))));
		        	element = driver.findElement(By.id(snameId));
		        	System.out.println("Trying to find element " + element.toString()); 
		            return element;
		        }
		    });
		}
	
	
	
	
	
	
	
	

}
