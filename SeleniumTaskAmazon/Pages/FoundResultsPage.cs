using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTaskAmazon.Models;
using System;
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

        public IWebElement FirstResult => FoundResults.ElementAtOrDefault(0);// .FirstOrDefault();

        public IWebElement GetElementAtPosition(int position)
        {
            return FoundResults.ElementAtOrDefault(position);
        }

        public string GetFoundElementTitle(int position)
        {
            IWebElement foundElement = GetElementAtPosition(position);
            string foundTitle = foundElement.FindElement(foundElementTitle).Text;

            return foundTitle;
        }

        public string GetFoundElementFormat(int position)
        {
            IWebElement foundElement = GetElementAtPosition(position);
            string foundFormat = foundElement.FindElement(foundElementFormat).Text;

            return foundFormat;
        }

        public double GetFoundElementPrice(int position)
        {
            IWebElement foundElement = GetElementAtPosition(position);
            string foundPriceAsText = foundElement.FindElements(foundElementPrice).First().Text;
            double price = ParcePrice(foundPriceAsText);

            return price;
        }

        public bool GetFoundElementBadge(int position)
        {
            IWebElement foundElement = GetElementAtPosition(position);
            bool foundKindleBadge;
            bool foundPrimeBadge;

            try
            {
                IWebElement badge = foundElement.FindElements(foundElementPrice).First().FindElement(foundElementKindleBadge);
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
                IWebElement badge = foundElement.FindElements(foundElementPrice).First().FindElement(foundElementPrimeBadge);
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

        public Book GetFoundBook(int position)
        {
            Format foundItemFormat;
            Enum.TryParse(GetFoundElementFormat(position), out foundItemFormat);

            return new Book
            {
                Title = GetFoundElementTitle(position),
                Price = GetFoundElementPrice(position),
                Badge = GetFoundElementBadge(position),
                Format = foundItemFormat
            };
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
