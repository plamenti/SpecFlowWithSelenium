﻿using SeleniumTaskAmazon.Pages;
using TechTalk.SpecFlow;

namespace SeleniumTaskAmazon.StepDefinitions
{
    [Binding]
    public class SearchForBooksSteps
    {
        private HomePage page = ScenarioContext.Current.Get<HomePage>();

        [When(@"I select category (.*)")]
        public void SelectCategory(string category)
        {
            page.SelectCategory(category);
        }

        [When(@"Search for book with title (.*)")]
        public void SearchForBookByTitle(string title)
        {
            page.SearchForItem(title);
        }

        [Then(@"First found item has following attributes")]
        public void VerifyFirstItem(Table table)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
