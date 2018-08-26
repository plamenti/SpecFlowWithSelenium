using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumTaskAmazon.Models;

namespace SeleniumTaskAmazon.Pages
{
    public class BookDetailsPage : BasePage
    {
        private By title = By.Id("productTitle");
        private By badge = By.XPath("//div[contains(@id, 'Badge')]//i");
        private By price = By.XPath("//li[contains(@class,' selected')]//a[@role='button']/span[2]");
        private By format = By.XPath("//li[contains(@class,' selected')]//a[@role='button']/span[1]");
        private By addToBasketButton = By.Id("add-to-cart-button");

        public BookDetailsPage(IWebDriver driver, IWait<IWebDriver> wait) : base(driver, wait)
        {
        }

        public override bool IsAt()
        {
            return CheckElementIsVisible(title) && CheckElementIsVisible(price);
        }

        public string GetTitle()
        {
            return GetElementText(title);
        }

        public bool GetBadge()
        {
            return CheckElementIsVisible(badge);
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

        public void AddBookToBasket()
        {
            Click(addToBasketButton);
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

