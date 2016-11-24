package egged.hourbank.utils;

import java.util.Set;
import java.util.concurrent.TimeUnit;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import org.openqa.selenium.By;
import org.openqa.selenium.ElementNotVisibleException;
import org.openqa.selenium.NoSuchWindowException;
import org.openqa.selenium.StaleElementReferenceException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.How;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.FluentWait;
import org.openqa.selenium.support.ui.WebDriverWait;

import com.google.common.base.Function;

import egged.hourbank.pageobjects.Managment;
import egged.hourbank.pageobjects.Main;

public   class Common   {

	private static WebElement element;
	public WebDriver driver;
	int attempts = 0;
	int MAX_ATTEMPTS = 20;
	
	
	@FindBy(how = How.ID, using = "dialog-message")
	public static WebElement dialogMessage;
	
	
	@FindBy(how = How.ID, using = "okbtn")
	public static WebElement btnAccept;
	
	
	public static  String getDialogText () {
		
		
		return  dialogMessage.getText();
		
		
		
	}
	
	
	
public static void clickAccept ()  {
		
		btnAccept.click();
		
	}


public static String getActualText(String txt , String symbol) {
	
	

	String actualtext = txt;
			
	String[] actualsplit = actualtext.split(symbol);
	
	String actual = actualsplit[0];	
	
	return actual;
	
	
	
	
}
	
	
	
	
	
	
	
	

	public void waitForWindow(String regex, WebDriver driver) {

		try {
			Set<String> windows = driver.getWindowHandles();
			System.out.println(windows);

			for (String window : windows) {
				try {
					driver.switchTo().window(window);

					Pattern p = Pattern.compile(regex);
					Matcher m = p.matcher(driver.getCurrentUrl());

					if (m.find()) {
						attempts = 0;
						switchToWindow(regex, driver);
						return;
					} else {
						// try for title
						m = p.matcher(driver.getTitle());

						// if (driver.getCurrentUrl().indexOf("WorkCard")>-1){
						if (m.find()) {
							attempts = 0;
							switchToWindow(regex, driver);
							return;
						}
					}
				} catch (NoSuchWindowException e) {
					if (attempts <= MAX_ATTEMPTS) {
						attempts++;

						try {
							Thread.sleep(1);
						} catch (Exception x) {
							x.printStackTrace();
						}

						waitForWindow(regex, driver);
						return;
					} else {
						fail("Window with url|title: " + regex
								+ " did not appear after " + MAX_ATTEMPTS
								+ " tries. Exiting.");
					}
				}
			}

			// when we reach this point, that means no window exists with that
			// title..
			if (attempts == MAX_ATTEMPTS) {
				fail("Window with title: " + regex
						+ " did not appear after 5 tries. Exiting.");
				return;
			} else {
				System.out
						.println("#waitForWindow() : Window doesn't exist yet. ["
								+ regex
								+ "] Trying again. "
								+ attempts
								+ "/"
								+ MAX_ATTEMPTS);
				attempts++;
				waitForWindow(regex, driver);
				return;
			}

		} catch (NullPointerException e)

		{
			System.out.print("NullPointerException caught");
		}

	}

	public void switchToWindow(String regex, WebDriver driver) {
		Set<String> windows = driver.getWindowHandles();

		for (String window : windows) {
			driver.switchTo().window(window);
			System.out.println(String.format(
					"#switchToWindow() : title=%s ; url=%s", driver.getTitle(),
					driver.getCurrentUrl()));

			Pattern p = Pattern.compile(regex);
			Matcher m = p.matcher(driver.getTitle());

			if (m.find())
				return;
			else {
				m = p.matcher(driver.getCurrentUrl());
				if (m.find())
					return;
			}
		}

		fail("Could not switch to window with title / url: " + regex);
		return;
	}

	private void fail(String string) {
		System.out.println(string);

	}

	public static int GetNumWindows(WebDriver driver) {
		return driver.getWindowHandles().size();

	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	


	public static WebElement Wait_For_Element_Visibile(final WebDriver driver,
			final int timeoutSeconds, String snameId, String sclassName, String sxpath) {
		FluentWait<WebDriver> wait = new FluentWait<WebDriver>(driver)

				.withTimeout(timeoutSeconds, TimeUnit.SECONDS)
				.pollingEvery(500, TimeUnit.MILLISECONDS)
				.ignoring(StaleElementReferenceException.class,
						ElementNotVisibleException.class);

		return wait.until(new Function<WebDriver, WebElement>() {
			public WebElement apply(WebDriver webDriver) {

				if (snameId != null) {
					WebDriverWait wait = new WebDriverWait(driver, 50);
					wait.until(ExpectedConditions.visibilityOf(driver
							.findElement(By.id(snameId))));
					element = driver.findElement(By.id(snameId));
				}

				if (sclassName!=null) {

					WebDriverWait wait = new WebDriverWait(driver, 50);
					wait.until(ExpectedConditions.visibilityOf(driver
							.findElement(By.className(sclassName))));
					element = driver.findElement(By.className(sclassName));
				}
				
				
				
				
				if (sxpath!=null) {
					
					WebDriverWait wait = new WebDriverWait(driver, 50);
					wait.until(ExpectedConditions.visibilityOf(driver
							.findElement(By.xpath(sxpath))));
					element = driver.findElement(By.xpath(sxpath));
					
					
					
					
					
				}

				System.out.println("Trying to find element "
						+ element.toString());
				return element;
			}
		});
	}
	
	
	
	

	public static WebElement Wait_For_Element_Stalenes(WebDriver driver,
			String snameId, String sclassname) {

		if (snameId != null) {
			WebDriverWait wait = new WebDriverWait(driver, 120);
			wait.until(ExpectedConditions.stalenessOf((driver.findElement(By
					.id(snameId)))));
		}

		else

		{
			WebDriverWait wait1 = new WebDriverWait(driver, 120);
			wait1.until(ExpectedConditions.stalenessOf((driver.findElement(By
					.className(sclassname)))));
		}

		return element;
	}
	
	
	
	
	
	
	
	
	

  	
	

	

	
	
	
	

}
