using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

public class DriverContainer { 
    static void Main(string[] args) { // Endpoint for .NET application
        ChromeOptions options = new ChromeOptions(); // Instance ChromeOptions class, allowing for Chrome settings to be altered
        string driverpath = @"path"; // DriverPath to ensure chrome driver is correctly called in
        options.AddArgument("--disable-notifications"); // Disable all notifications that could possibly affect the automation
        IWebDriver driver = new ChromeDriver(driverpath, options); // Instance IWebDriver interface and initiate the ChromeDriver class, opening a Chrome browser

        driver.Navigate().GoToUrl("https://example.template.com/"); // Navigating the driver to the Chrome URL

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Timer creation in case future conditions fail, linked to ChromeDriver and lasting 10 seconds. 

        try { // Username input linked to timer

        /*
        Login input linked to timer.
        Followed by JS executor, allowing for JS code to be imported and used.
        Executor script scrolls through source code and locates element, used as a double check. 
        */

            IWebElement loginInput = wait.Until(driver => driver.FindElement(By.Id("login_id")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", loginInput); 
            loginInput.SendKeys("username");
            loginInput.SendKeys(Keys.Enter);

        }
        catch (WebDriverTimeoutException) {

            Console.WriteLine("Failure to log username. Please retry.")
        }

        try {

            IWebElement passInput = wait.Until(driver => driver.FindElement(By.Id("password")));
            passInput.SendKeys("password");
            passInput.SendKeys(Keys.Enter);
        }
        catch (WebDriverTimeoutException) {

            Console.WriteLine("Failure to log password. Please retry.")
        }

        try {

            IWebElement userTicket = wait.Until(driver => driver.FindElement(By.CssSelector(".zd_v2-listlayout-container.zd_v2-listlayout-varClass.zd_v2-modulelistnew-listContainer.zd_v2-modulelistnew-hoverContainer.zd_v2-modulelistnew-classic")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", userTicket);
            userTicket.Click();
        }
        catch (WebDriverTimeoutException) {

            Console.WriteLine("Unable to locate User Ticket. Please retry.")
        }

        driver.Quit();
    }
}

