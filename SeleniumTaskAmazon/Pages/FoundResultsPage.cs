using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Linq;

namespace SeleniumTaskAmazon.Pages
{
    public class FoundResultsPage : BasePage
    {
        private By resultsContainer = By.Id("s-results-list-atf");
        private By allResults = By.XPath("//li[contains(@id, 'result_')]");
        private By foundElementTitle = By.TagName("h2");
        private By foundElementFormat = By.TagName("h3");
        private By foundElementPrice = By.XPath("//span[contains(@class, 'a-color-price')]");
        private By foundElementKindleBadge = By.XPath("./parent::a/following-sibling::span[contains(@class, 's-icon-kindle-unlimited')]");
        private By foundElementPrimeBadge = By.XPath("./parent::a/following-sibling::i[contains(@class, 'a-icon-prime')]");

        public FoundResultsPage(IWebDriver driver, IWait<IWebDriver> wait) : base(driver, wait)
        {
        }

        public ReadOnlyCollection<IWebElement> FoundResults => driver.FindElements(allResults);

        public IWebElement FirstResult => FoundResults.FirstOrDefault();

        public string GetFirstFoundElementTitle()
        {
            string foundTitle = FirstResult.FindElement(foundElementTitle).Text;

            return foundTitle;
        }

        public string GetFirstFoundElementFormat()
        {
            string foundFormat = FirstResult.FindElement(foundElementFormat).Text;

            return foundFormat;
        }

        public double GetFirstFoundElementPrice()
        {
            string foundPriceAsText = driver.FindElements(foundElementPrice).First().Text;
            double price = ParcePrice(foundPriceAsText);

            return price;
        }

        public bool GetFirstFoundElementBadge()
        {

            bool foundKindleBadge;
            bool foundPrimeBadge;

            try
            {
                IWebElement badge = FirstResult.FindElements(foundElementPrice).First().FindElement(foundElementKindleBadge);
                foundKindleBadge = true;
            }
            catch (NoSuchElementException)
            {
                foundKindleBadge = false;
            }
            catch (WebDriverTimeoutException)
            {
                foundKindleBadge = false;
            }

            try
            {
                IWebElement badge = FirstResult.FindElements(foundElementPrice).First().FindElement(foundElementPrimeBadge);
                foundPrimeBadge = true;
            }
            catch (NoSuchElementException)
            {
                foundPrimeBadge = false;
            }
            catch (WebDriverTimeoutException)
            {
                foundPrimeBadge = false;
            }


            return foundKindleBadge || foundPrimeBadge;
        }

        public override bool IsAt()
        {
            bool isResultsContainerVisible = CheckElementIsVisible(resultsContainer);

            return isResultsContainerVisible && FoundResults.Count > 0;
        }

        private double ParcePrice(string foundPriceAsText)
        {
            string trimedPrice = foundPriceAsText.Trim(new char[] { '£' });

            return double.Parse(trimedPrice);
        }
    }
}
