using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTaskAmazon.Helpers;
using TechTalk.SpecFlow;

namespace SeleniumTaskAmazon.StepDefinitions
{
    [Binding]
    public class BootstrapSteps
    {
        private IWebDriver driver;
        private IWait<IWebDriver> wait;

        [BeforeScenario]
        public void setupDriver()
        {
            driver = DriverManager.GetDriver();
            wait = WaitManager.GetDefaultWait(driver);
            ScenarioContext.Current.Set<IWebDriver>(driver);
            ScenarioContext.Current.Set<IWait<IWebDriver>>(wait);
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
