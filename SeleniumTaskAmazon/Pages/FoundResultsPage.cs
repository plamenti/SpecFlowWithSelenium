using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SeleniumTaskAmazon.Pages
{
    public class FoundResultsPage : BasePage
    {
        private By resultsContainer = By.Id("s-results-list-atf");
        private By allResults = By.XPath("//li[contains(@id, 'result_')]");
        private By foundElementTitle = By.TagName("h2"); // By.XPath("//h2");
        private By foundElementFormat = By.TagName("h3"); // By.XPath("//h2");
        private By foundElementPrice = By.XPath("//span[contains(@class, 'a-color-price')]");
        private By foundElementKindleBadge = By.XPath("//span[contains(@class, 's-icon-kindle-unlimited')]");
        private By foundElementPrimeBadge = By.XPath("//i[contains(@class, 'a-icon-prime')]");

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
            string foundPriceAsText = FirstResult.FindElements(foundElementPrice).First().Text;
            double price = ParcePrice(foundPriceAsText);

            return price;
        }

        public bool GetFirstFoundElementBadge()
        {

            bool foundKindleBadge;
            bool foundPrimeBadge;

            try
            {
                IWebElement badge = FirstResult.FindElement(foundElementKindleBadge);
                foundKindleBadge = true;
            }
            catch (NoSuchElementException ex)
            {
                foundKindleBadge = false;
            }
            catch (WebDriverTimeoutException ex)
            {
                foundKindleBadge = false;
            }

            try
            {
                IWebElement badge = FirstResult.FindElement(foundElementPrimeBadge);
                foundPrimeBadge = true;
            }
            catch (NoSuchElementException ex)
            {
                foundPrimeBadge = false;
            }
            catch (WebDriverTimeoutException ex)
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

        public override void NavigateTo()
        {
            throw new NotImplementedException();
        }

        private double ParcePrice(string foundPriceAsText)
        {
            string trimedPrice = foundPriceAsText.Trim(new char[] { '£' });

            return double.Parse(trimedPrice);
        }
    }
}
