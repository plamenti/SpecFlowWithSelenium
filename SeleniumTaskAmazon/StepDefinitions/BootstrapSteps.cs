using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTaskAmazon.Helpers;
using SeleniumTaskAmazon.Pages;
using TechTalk.SpecFlow;

namespace SeleniumTaskAmazon.StepDefinitions
{
    [Binding]
    public class BootstrapSteps
    {
        private IWebDriver driver;
        private IWait<IWebDriver> wait;
        private HomePage page;

        [BeforeScenario]
        public void setupDriver()
        {
            driver = DriverManager.GetDriver();
            wait = WaitManager.GetDefaultWait(driver);
            page = new HomePage(driver, wait);
            ScenarioContext.Current.Set<IWebDriver>(driver);
            ScenarioContext.Current.Set<IWait<IWebDriver>>(wait);
            ScenarioContext.Current.Set<HomePage>(page);
        }

        [AfterScenario]
        public void tearDownDriver()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
    }
}
