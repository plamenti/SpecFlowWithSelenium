using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumTaskAmazon.Helpers;
using SeleniumTaskAmazon.Models;
using SeleniumTaskAmazon.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumTaskAmazon.StepDefinitions
{
    [Binding]
    public class SearchForBooksSteps
    {
        private HomePage homePage = ScenarioContext.Current.Get<HomePage>();
        private FoundResultsPage foundReusultsPage = ScenarioContext.Current.Get<FoundResultsPage>();
        private BookDetailsPage bookDetailsPage = ScenarioContext.Current.Get<BookDetailsPage>();
        private IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>();
        private ExtentTest extentTest = ScenarioContext.Current.Get<ExtentTest>();
        private Book expectedBook;
        private Book actualBook;

        [When(@"I select category (.*)")]
        public void SelectCategory(string category)
        {
            homePage.SelectCategory(category);
        }

        [When(@"Search for book with title (.*)")]
        public void SearchForBookByTitle(string title)
        {
            homePage.SearchForItem(title);
        }

        [Then(@"(.*) found book has following attributes")]
        public void VerifyFirstItem(int position, Table table)
        {
            expectedBook = table.CreateInstance<Book>();
            actualBook = foundReusultsPage.GetFoundBook(position);
            ScenarioContext.Current.Set<Book>(actualBook);

            VerifyBooksAreEquals(expectedBook, actualBook);
        }

        [When(@"Navigate to (.*) found book details")]
        public void NavigateToBookDetails(int position)
        {
            foundReusultsPage.NavigateToFoundBookDetails(position);
        }

        [Then(@"I am on the book details page")]
        public void ThenIAmOnTheBookDetailsPage()
        {
            AssertionsManager.IsTrue(driver, extentTest, bookDetailsPage.IsAt(), $"Book details page is operational: {bookDetailsPage.IsAt().ToString()}");
        }

        [Then(@"The book has following attributes")]
        public void VerifyBookBookDetails(Table table)
        {
            expectedBook = table.CreateInstance<Book>();
            actualBook = bookDetailsPage.GetBook();

            VerifyBooksAreEquals(expectedBook, actualBook);
        }

        private void VerifyBooksAreEquals(Book expectedBook, Book actualBook)
        {
            AssertionsManager.IsTrue(driver, extentTest, actualBook.Title.Contains(expectedBook.Title), $"Actual Title: {actualBook.Title} does contain: {expectedBook.Title}");
            AssertionsManager.IsTrue(driver, extentTest, expectedBook.Badge == actualBook.Badge, $"Expected Badge: {expectedBook.Badge}, it was: {actualBook.Badge}");
            AssertionsManager.IsTrue(driver, extentTest, expectedBook.Format == actualBook.Format, $"Expected Format: {expectedBook.Format}, it was: {actualBook.Format}");
            AssertionsManager.IsTrue(driver, extentTest, expectedBook.Price == actualBook.Price, $"Expected Price: {expectedBook.Price}, it was: {actualBook.Price}");
        }

    }
}
