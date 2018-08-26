﻿using OpenQA.Selenium;
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
        private HomePage homePage;
        private FoundResultsPage foundResultsPage;
        private BookDetailsPage bookDetailsPage;
        private BasketPage basketPage;

        [BeforeScenario]
        public void setupDriver()
        {
            driver = DriverManager.GetDriver();
            wait = WaitManager.GetDefaultWait(driver);
            homePage = new HomePage(driver, wait);
            bookDetailsPage = new BookDetailsPage(driver, wait);
            foundResultsPage = new FoundResultsPage(driver, wait);
            basketPage = new BasketPage(driver, wait); 
            ScenarioContext.Current.Set<IWebDriver>(driver);
            ScenarioContext.Current.Set<IWait<IWebDriver>>(wait);
            ScenarioContext.Current.Set<HomePage>(homePage);
            ScenarioContext.Current.Set<FoundResultsPage>(foundResultsPage);
            ScenarioContext.Current.Set<BookDetailsPage>(bookDetailsPage);
            ScenarioContext.Current.Set<BasketPage>(basketPage);
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
