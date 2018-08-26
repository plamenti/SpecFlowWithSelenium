using NUnit.Framework;
using SeleniumTaskAmazon.Models;
using SeleniumTaskAmazon.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumTaskAmazon.StepDefinitions
{
    [Binding]
    public class SearchForBooksSteps
    {
        private HomePage homePage = ScenarioContext.Current.Get<HomePage>();
        private FoundResultsPage foundReusultsPage = ScenarioContext.Current.Get<FoundResultsPage>();
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

        [Then(@"First found item has following attributes")]
        public void VerifyFirstItem(Table table)
        {
            expectedBook = table.CreateInstance<Book>();
            Format foundItemFormat;
            Enum.TryParse(foundReusultsPage.GetFirstFoundElementFormat(), out foundItemFormat);
            actualBook = new Book
            {
                Title = foundReusultsPage.GetFirstFoundElementTitle(),
                Price = foundReusultsPage.GetFirstFoundElementPrice(),
                Badge = foundReusultsPage.GetFirstFoundElementBadge(),
                Format = foundItemFormat
            };

            Assert.IsTrue(actualBook.Title.Contains(expectedBook.Title), "Title is not equal");
            Assert.IsTrue(expectedBook.Badge == actualBook.Badge, "Badge is not equal");
            Assert.IsTrue(expectedBook.Format == actualBook.Format, "Format is not equal");
            Assert.IsTrue(expectedBook.Price == actualBook.Price, "Price is not equal");
        }

    }
}
