﻿using NUnit.Framework;
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
        private BookDetailsPage bookDetailsPage = ScenarioContext.Current.Get<BookDetailsPage>();
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
            Assert.IsTrue(bookDetailsPage.IsAt(), "Book details page is not operational");
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
            Assert.IsTrue(actualBook.Title.Contains(expectedBook.Title), $"Actual Title: {actualBook.Title} does not contain: {expectedBook.Title}");
            Assert.IsTrue(expectedBook.Badge == actualBook.Badge, $"Expected Badge: {expectedBook.Badge} but was: {actualBook.Badge}");
            Assert.IsTrue(expectedBook.Format == actualBook.Format, $"Expected Format: {expectedBook.Format} but was: {actualBook.Format}");
            Assert.IsTrue(expectedBook.Price == actualBook.Price, $"Expected Price: {expectedBook.Price} but was: {actualBook.Price}");
        }

    }
}
