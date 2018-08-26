using SeleniumTaskAmazon.Pages;
using TechTalk.SpecFlow;

namespace SeleniumTaskAmazon.StepDefinitions
{
    [Binding]
    public class BasketOperationsSteps
    {
        private BookDetailsPage bookDetailsPage = ScenarioContext.Current.Get<BookDetailsPage>();
        private BasketPage basketPage = ScenarioContext.Current.Get<BasketPage>();


    }
}
