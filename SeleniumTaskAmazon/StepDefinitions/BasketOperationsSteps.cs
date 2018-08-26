using NUnit.Framework;
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

        [Then(@"The book is shown on the list")]
        public void ThenTheBookIsShownOnTheList()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The book is the same as on the search page")]
        public void ThenTheBookIsTheSameAsOnTheSearchPage()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Quantity is (.*)")]
        public void ThenQuantityIs(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Total price is equal to quantity times book price")]
        public void ThenTotalPriceIsEqualToQuantityTimesBookPrice()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
