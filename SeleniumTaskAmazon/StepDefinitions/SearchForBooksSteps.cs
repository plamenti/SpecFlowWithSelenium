using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumTaskAmazon.StepDefinitions
{
    [Binding]
    public class SearchForBooksSteps
    {
        [When(@"I select section (.*)")]
        public void SelectSection(string section)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Search for book with title (.*)")]
        public void SearchForBookByTitle(string title)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"First found item has following attributes")]
        public void VerifyFirstItem(Table table)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
