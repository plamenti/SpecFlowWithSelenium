using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumTaskAmazon.Helpers;
using SeleniumTaskAmazon.Pages;
using TechTalk.SpecFlow;

namespace SeleniumTaskAmazon.StepDefinitions
{
    [Binding]
    public class SelectBookSteps
    {
        private HomePage page = ScenarioContext.Current.Get<HomePage>();
        private IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>();
        private ExtentTest extentTest = ScenarioContext.Current.Get<ExtentTest>();

        [Given(@"I navigate to Amazon book store in UK")]
        public void NavigateToStore()
        {
            page.NavigateTo();
        }

        [Given(@"I am not logged in")]
        public void VerifyIAmNotLoggedIn()
        {
            string greetingLabelName = "Sign in";

            AssertionsManager.IsTrue(driver, extentTest, page.IsLoggedInAs(greetingLabelName), $"Greeting label: {greetingLabelName}");
        }

        [Then(@"The correct page is open")]
        public void VerifyCorrectPageIsOpen()
        {
            string expectedUrl = @"https://www.amazon.co.uk/";
            string expectedTitle = "Amazon.co.uk: Low Prices in Electronics, Books, Sports Equipment & more";

            AssertionsManager.AreEqual(driver, extentTest, expectedUrl, page.GetCurrentUrl(), $"Page url: {page.GetCurrentUrl()}");
            AssertionsManager.AreEqual(driver, extentTest, expectedTitle, page.GetTitle(), $"Page title: {page.GetTitle()}");
            AssertionsManager.IsTrue(driver, extentTest, page.IsAt(), $"Book store page is operational: {page.IsAt().ToString()}");
        }

        [Then(@"I can start to search for books")]
        public void VerifyCanStartToSearchForBooks()
        {
            AssertionsManager.IsTrue(driver, extentTest, page.CanSearch(), $"Can start to search: {page.CanSearch().ToString()}");
        }
    }
}
