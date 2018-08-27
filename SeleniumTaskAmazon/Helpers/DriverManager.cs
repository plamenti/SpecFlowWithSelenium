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
            string infoMessage = $"Driver type: {driverType}";

            switch (driverType)
            {
                case "chrome":
                    driver = new ChromeDriver();
                    SetupDriverProperties(driver);
                    LoggingManager.LogInfo(infoMessage);
                    return driver;

                case "firefox":
                    driver = new FirefoxDriver();
                    SetupDriverProperties(driver);
                    LoggingManager.LogInfo(infoMessage);
                    return driver;

                case "ie":
                    var options = new InternetExplorerOptions
                    {
                        IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                        IgnoreZoomLevel = true,
                        EnableNativeEvents = false
                    };

                    driver = new InternetExplorerDriver(options);
                    SetupDriverProperties(driver);
                    LoggingManager.LogInfo(infoMessage);
                    return driver;

                case "edge":
                    driver = new EdgeDriver();
                    SetupDriverProperties(driver);
                    LoggingManager.LogInfo(infoMessage);
                    return driver;

                default:
                    string errorMessage = $"Invalid browser name argument! No such browser: {driverType}";
                    LoggingManager.LogError(errorMessage);
                    throw new ArgumentException(errorMessage);
            }
        } 

        public static void TearDownDriver(IWebDriver driver)
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }

        private static void SetupDriverProperties(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
        }
    }
}
