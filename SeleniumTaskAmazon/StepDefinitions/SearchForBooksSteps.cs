using TechTalk.SpecFlow;

namespace SeleniumTaskAmazon.StepDefinitions
{
    [Binding]
    public class SearchForBooksSteps
    {
        [When(@"I select category (.*)")]
        public void SelectCategory(string category)
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
