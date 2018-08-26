using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumTaskAmazon.Models;

namespace SeleniumTaskAmazon.Pages
{
    public class BookDetailsPage : BasePage
    {
        private By tile = By.Id("productTitle");
        private By badge = By.XPath("//div[contains(@id, 'Badge')]//i");
        private By price = By.XPath("//li[contains(@class,' selected')]//a[@role='button']/span[2]");
        private By format = By.XPath("//li[contains(@class,' selected')]//a[@role='button']/span[1]");

        public BookDetailsPage(IWebDriver driver, IWait<IWebDriver> wait) : base(driver, wait)
        {
        }

        public override bool IsAt()
        {
            throw new NotImplementedException();
        }

        public string GetTitle()
        {
            return GetElementText(tile);
        }

        public bool GetBadge()
        {
            bool foundBadge;

            try
            {
                IWebElement badgeElement = GetElement(badge);
                foundBadge = true;
            }
            catch (NoSuchElementException)
            {
                foundBadge = false;
            }
            catch (WebDriverTimeoutException)
            {
                foundBadge = false;
            }

            return foundBadge;
    }

    public string GetFormat()
        {
            IWebElement foundElement = GetElement(format); ;

            return foundElement.Text;
        }

        public double GetPrice()
        {
            string foundPriceAsText = GetElement(price).Text;
            double priceValue = ParcePrice(foundPriceAsText);

            return priceValue;
        }

        public Book GetBook()
        {
            Format foundItemFormat;
            Enum.TryParse(GetFormat(), out foundItemFormat);

            return new Book
            {
                Title = GetTitle(),
                Price = GetPrice(),
                Badge = GetBadge(),
                Format = foundItemFormat
            };
        }

    }
}

