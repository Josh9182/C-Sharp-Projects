using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;

public class DriverContainer {
    static void Main(string[] args) { // Endpoint for .NET application
        ChromeOptions options = new ChromeOptions(); // Instance ChromeOptions class, allowing for Chrome settings to be altered
        options.AddArgument("--disable-notifications"); // Disable all notifications that could possibly affect the automation

        IWebDriver driver = new ChromeDriver(options); // Instance IWebDriver interface and initiate the ChromeDriver class, opening a Chrome browser
        driver.Navigate().GoToUrl("https://example.template.com/"); // Navigating the driver to the Chrome URL
        
        IAlert alert = driver.SwitchTo().Alert(); // Instance the IAlert method, allowing for JavaScript notification manipulation
        alert.Dismiss(); // Dismiss all notifications

        driver.FindElement(By.Name("example.input.field1111.username")).Click();
        driver.FindElement(By.Name("example.input.field1111.username")).SendKeys("username"); // Click and fill in the username input box

        driver.FindElement(By.Name("example.input.field1111.password")).Click();
        driver.FindElement(By.Name("example.input.field1111.password")).SendKeys("password"); // Click and fill in the password input box
        

        driver.Quit();
      
    }
}
