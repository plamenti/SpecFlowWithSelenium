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

            //TODO: Log steps
            switch (driverType)
            {
                case "chrome":
                    return new ChromeDriver();
                case "firefox":
                    return new FirefoxDriver();
                case "ie":
                    var options = new InternetExplorerOptions
                    {
                        IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                        IgnoreZoomLevel = true,
                        EnableNativeEvents = false
                    };

                    return new InternetExplorerDriver(options);
                case "edge":
                    return new EdgeDriver();
                default:
                    //TODO: Log Error
                    Console.WriteLine($"No such browser: {driverType}");
                    throw new ArgumentException("Invalid browser name argument!");
            }
        }
    }
}
