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

    }
}
