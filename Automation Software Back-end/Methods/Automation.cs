using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System;

public class DriverContainer {
    static void Main(string[] args) { // Endpoint for .NET application
        ChromeOptions options = new ChromeOptions(); // Instance ChromeOptions class, allowing for Chrome settings to be altered
        options.AddArgument("--disable-notifications"); // Disable all notifications that could possibly affect the automation
        IWebDriver driver = new ChromeDriver(options); // Instance IWebDriver interface and initiate the ChromeDriver class, opening a Chrome browser
        
        driver.Navigate().GoToUrl("https://example.template.com/"); // Navigating the driver to the Chrome URL

        DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver) { // DefaultWait class temp instanced into the driver   
            Timeout = TimeSpan.FromSeconds(10), // Timer that will stop execution of webdriver after a custom timer. 
            PollingInterval = TimeSpan.FromSeconds(5)}; // Refreshing interval that will try every n amount of seconds to search for future conditions. 
        
        IAlert alert = driver.SwitchTo().Alert(); // Instance the IAlert method, allowing for JavaScript notification manipulation
        alert.Dismiss(); // Dismiss all notifications

        IWebElement loginInput = wait.Until(driver => driver.FindElement(By.Id("login_id"))); // Variable that activates the wait instance above combined with the "Until" condition.
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", loginInput); // driver instance cast into JavaScript interface for the sake of executing JS code to scroll the source code down until the first argument is found, I.E "loginInput"
        Thread.Sleep(500); // Pause the automation for 0.5 seconds in order to let dynamic values load in 
        loginInput.SendKeys("username"); // Type the username into the input element
        loginInput.SendKeys(Keys.Enter); // Submit element

        Thread.Sleep(500); 
        IWebElement passInput = wait.Until(driver => driver.FindElement(By.Id("pass_id")));
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", passInput);
        passInput.SendKeys("password");
        passInput.SendKeys(Keys.Enter);

        driver.Quit();
    }
}

