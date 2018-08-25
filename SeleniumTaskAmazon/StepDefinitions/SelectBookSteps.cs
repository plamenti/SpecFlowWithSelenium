using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTaskAmazon.Helpers;
using SeleniumTaskAmazon.Pages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumTaskAmazon.StepDefinitions
{
    [Binding]
    public class SelectBookSteps
    {
        private HomePage page;
        private IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>();
        private IWait<IWebDriver> wait = ScenarioContext.Current.Get<IWait<IWebDriver>>();

        [Given(@"I navigate to Amazon book store in UK")]
        public void NavigateToStore()
        {
            page = new HomePage(driver, wait);
            page.NavigateTo();
        }

        [Given(@"I am not logged in")]
        public void VerifyIAmNotLoggedIn()
        {
            string greetingLabelName = "Sign in";
            Assert.True(page.IsLoggedInAs(greetingLabelName), $"Greeting label should contain: {greetingLabelName}");
        }

        [Then(@"The correct page is open")]
        public void VerifyCorrectPageIsOpen()
        {
            string expectedUrl = @"https://www.amazon.co.uk/";
            string expectedTitle = "Amazon.co.uk: Low Prices in Electronics, Books, Sports Equipment & more";

            Assert.AreEqual(expectedUrl, page.GetCurrentUrl());
            Assert.AreEqual(expectedTitle, page.GetTitle());
            Assert.True(page.IsAt());
        }

        [Then(@"I can start to search for books")]
        public void VerifyCanStartToSearchForBooks()
        {
            Assert.True(page.CanSearch());
        }
    }
}
