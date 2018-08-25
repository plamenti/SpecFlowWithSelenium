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
        [When(@"I select section books")]
        public void WhenISelectSectionBooks()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Search for book with title (.*)")]
        public void WhenSearchForBookWithTitle(string title)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"First item has following attributes")]
        public void ThenFirstItemHasFollowingAttributes(Table table)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
