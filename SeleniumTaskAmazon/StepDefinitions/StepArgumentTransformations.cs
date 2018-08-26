using TechTalk.SpecFlow;

namespace SeleniumTaskAmazon.StepDefinitions
{
    [Binding]
    public class StepArgumentTransformations
    {
        [StepArgumentTransformation(@"(\d+)(?:st|nd|rd|th)")]
        public int GetIndex(int index)
        {
            return index - 1;
        }
    }
}
