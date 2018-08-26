using NUnit.Framework;
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
            Assert.IsTrue(basketPage.IsAt(), "Notification Book is added to the basket is not operational");
        }

        [Then(@"Notification title is (.*)")]
        public void VerifyTitle(string expectedTitle)
        {
            string actualTitle = basketPage.GetLabelTitle();

            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [Then(@"There is (.*) item in the basket")]
        public void VerifyItemsCount(int expectedItemsCount)
        {
            int actualItemsCount = basketPage.GetItemsCount();

            Assert.AreEqual(expectedItemsCount, actualItemsCount);
        }

        [Then(@"The book is the same as on the search page")]
        public void ThenTheBookIsTheSameAsOnTheSearchPage()
        {
            Book bookFromSearchPage = ScenarioContext.Current.Get<Book>();
            Book actualBook = basketPage.GetBook();

            Assert.AreEqual(bookFromSearchPage.Title, actualBook.Title);
            Assert.AreEqual(bookFromSearchPage.Format, actualBook.Format);
            Assert.AreEqual(bookFromSearchPage.Price, actualBook.Price);
        }

        [Then(@"Quantity is (.*)")]
        public void ThenQuantityIs(int quantity)
        {
            Assert.AreEqual(basketPage.GetQuantity(), quantity);
        }

        [Then(@"Total price is equal to quantity times book price")]
        public void ThenTotalPriceIsEqualToQuantityTimesBookPrice()
        {
            double expectedTotalPrice = basketPage.GetQuantity() * basketPage.GetProductPrice();

            Assert.AreEqual(expectedTotalPrice, basketPage.GetTotalPrice());
        }

    }
}
