using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Configuration;

namespace SeleniumTaskAmazon.Helpers
{
    public class DriverManager
    {
        public static IWebDriver GetDriver()
        {
            string driverType = ConfigurationManager.AppSettings.Get("driver").ToLower();
            IWebDriver driver;
            //TODO: Log steps
            switch (driverType)
            {
                case "chrome":
                    driver = new ChromeDriver();
                    setupDriverProperties(driver);
                    return driver;

                case "firefox":
                    driver = new FirefoxDriver();
                    setupDriverProperties(driver);
                    return driver;

                case "ie":
                    var options = new InternetExplorerOptions
                    {
                        IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                        IgnoreZoomLevel = true,
                        EnableNativeEvents = false
                    };

                    driver = new InternetExplorerDriver(options);
                    setupDriverProperties(driver);
                    return driver;

                case "edge":
                    driver = new EdgeDriver();
                    setupDriverProperties(driver);
                    return driver;

                default:
                    //TODO: Log Error
                    Console.WriteLine($"No such browser: {driverType}");
                    throw new ArgumentException("Invalid browser name argument!");
            }
        }

        private static void setupDriverProperties(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }
    }
}
