using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumTaskAmazon.Helpers;
using SeleniumTaskAmazon.Models;
using SeleniumTaskAmazon.Pages;
using TechTalk.SpecFlow;

namespace SeleniumTaskAmazon.StepDefinitions
{
    [Binding]
    public class BasketOperationsSteps
    {
        private BookDetailsPage bookDetailsPage = ScenarioContext.Current.Get<BookDetailsPage>();
        private BasketPage basketPage = ScenarioContext.Current.Get<BasketPage>();
        private IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>();
        private ExtentTest extentTest = ScenarioContext.Current.Get<ExtentTest>();

        [When(@"Add book to the basket")]
        public void AddBookToTheBasket()
        {
            bookDetailsPage.AddBookToBasket();
        }

        [When(@"I edit basket")]
        public void WhenIEditBasket()
        {
            basketPage.EditBasket();
        }

        [Then(@"The notification is shown")]
        public void VerifyNotificationIsShown()
        {
            AssertionsManager.IsTrue(driver, extentTest, basketPage.IsAt(), "Notification Book is added to the basket");
        }

        [Then(@"Notification title is (.*)")]
        public void VerifyTitle(string expectedTitle)
        {
            string actualTitle = basketPage.GetLabelTitle();

            AssertionsManager.AreEqual(driver, extentTest, expectedTitle, actualTitle, $"Notification title is: {actualTitle}");
        }

        [Then(@"There is (.*) item in the basket")]
        public void VerifyItemsCount(int expectedItemsCount)
        {
            int actualItemsCount = basketPage.GetItemsCount();

            AssertionsManager.AreEqual(driver, extentTest, expectedItemsCount, actualItemsCount, $"Items count in the basket is: {actualItemsCount}");
        }

        [Then(@"The book is the same as on the search page")]
        public void ThenTheBookIsTheSameAsOnTheSearchPage()
        {
            Book bookFromSearchPage = ScenarioContext.Current.Get<Book>();
            Book actualBook = basketPage.GetBook();

            AssertionsManager.AreEqual(driver, extentTest, bookFromSearchPage.Title, actualBook.Title, $"Book title is: {actualBook.Title}");
            AssertionsManager.AreEqual(driver, extentTest, bookFromSearchPage.Format, actualBook.Format, $"Book format is: {actualBook.Format.ToString()}");
            AssertionsManager.AreEqual(driver, extentTest, bookFromSearchPage.Price, actualBook.Price, $"Book price is: {actualBook.Price}");
        }

        [Then(@"Quantity is (.*)")]
        public void ThenQuantityIs(int quantity)
        {
            AssertionsManager.AreEqual(driver, extentTest, quantity, basketPage.GetQuantity(), $"Book quantity is: {basketPage.GetQuantity()}");
        }

        [Then(@"Total price is equal to quantity times book price")]
        public void ThenTotalPriceIsEqualToQuantityTimesBookPrice()
        {
            double expectedTotalPrice = basketPage.GetQuantity() * basketPage.GetProductPrice();

            AssertionsManager.AreEqual(driver, extentTest, expectedTotalPrice, basketPage.GetTotalPrice(), $"Total price is: {basketPage.GetTotalPrice()}");
        }

    }
}
