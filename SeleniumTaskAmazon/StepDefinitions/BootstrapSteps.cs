using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTaskAmazon.Helpers;
using SeleniumTaskAmazon.Pages;
using System.IO;
using TechTalk.SpecFlow;

namespace SeleniumTaskAmazon.StepDefinitions
{
    [Binding]
    public class BootstrapSteps
    {
        private static ExtentReports extentReports;
        private static ExtentTest extentTest;
        private static ExtentHtmlReporter htmlReporter;
        private static string reportsFolder;
        private IWebDriver driver;
        private IWait<IWebDriver> wait;
        private HomePage homePage;
        private FoundResultsPage foundResultsPage;
        private BookDetailsPage bookDetailsPage;
        private BasketPage basketPage;
        
        [BeforeTestRun]
        public static void SetupReport()
        {
            extentReports = new ExtentReports();
            reportsFolder = IOManager.CreateReportsDirectory();
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extentReports.Flush();
        }

        [BeforeFeature]
        public static void SetupFeture()
        {
            string pathToReport = Path.Combine(reportsFolder, FeatureContext.Current.FeatureInfo.Title);
            htmlReporter = new ExtentHtmlReporter(pathToReport + ".html");
            extentReports.AttachReporter(htmlReporter);
            extentTest = extentReports.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void SetupDriver()
        {
            driver = DriverManager.GetDriver();
            wait = WaitManager.GetDefaultWait(driver);
            extentTest = extentReports.CreateTest(ScenarioContext.Current.ScenarioInfo.Title);
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
            ScenarioContext.Current.Set<ExtentTest>(extentTest);
        }

        [AfterScenario]
        public void TearDownDriver()
        {
            DriverManager.TearDownDriver(driver);
        }

        [AfterScenario]
        public static void WrapUpReport()
        {
            switch (TestContext.CurrentContext.Result.Outcome.Status.ToString().ToLower())
            {
                case "passed":
                    ScenarioContext.Current.Get<ExtentTest>().Pass("Scenario execution completed successfully");
                    break;
                case "failed":
                    ScenarioContext.Current.Get<ExtentTest>().Fail("One or more errors occurred during scenario execution");
                    break;
                case "inconclusive":
                    ScenarioContext.Current.Get<ExtentTest>().Warning("Unable to determine status of scenario execution");
                    break;
                case "skipped":
                    ScenarioContext.Current.Get<ExtentTest>().Skip("Skipped scenario execution");
                    break;
                default:
                    ScenarioContext.Current.Get<ExtentTest>().Error("Error occurred during determination of scenario status");
                    break;
            }

            ScenarioContext.Current.Clear();
        }
    }
}
