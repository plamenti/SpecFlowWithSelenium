using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTaskAmazon.Models;
using System;

namespace SeleniumTaskAmazon.Pages
{
    public class BasketPage : BasePage
    {
        private By orderLabelContainer = By.Id("huc-v2-order-row-inner");
        private By proceedToCkeckoutButton = By.Id("hlb-ptc-btn-native");
        private By editBasketButton = By.Id("hlb-view-cart-announce");
        private By confirmationLabel = By.XPath("//div[contains(@id, 'order-row-confirm')]/h1");
        private By bookTumbnail = By.Id("huc-v2-order-row-images");
        private By basketCount = By.XPath("//div[@id='hlb-subcart']//span/span");
        private By productTitle = By.XPath("//span[contains(@class, 'sc-product-title')]");
        private By productPrice = By.XPath("//span[contains(@class, 'a-color-price') and contains(@class, 'sc-product-price')]");
        private By productFormat = By.XPath("//span[contains(@class, 'a-size-small') and contains(@class, 'sc-product-binding')]");
        private By totalPrice = By.XPath("//span[@id='sc-subtotal-amount-activecart']/span");
        private By totalCount = By.Id("sc-subtotal-label-activecart");
        private By quantity = By.XPath("//span[@class = 'a-dropdown-prompt']");

        public BasketPage(IWebDriver driver, IWait<IWebDriver> wait) : base(driver, wait)
        {
        }

        public override bool IsAt()
        {
            bool isOrderLabelContainerVsible = CheckElementIsVisible(orderLabelContainer);
            bool isEditBasketButtonVisible = CheckElementIsVisible(editBasketButton);
            bool isConfirmationLabelVisible = CheckElementIsVisible(confirmationLabel);
            bool isProceedToCkeckoutButtonVisible = CheckElementIsVisible(proceedToCkeckoutButton);
            bool isBookTumbnailVisible = CheckElementIsVisible(bookTumbnail);

            return isOrderLabelContainerVsible &&
                isEditBasketButtonVisible &&
                isConfirmationLabelVisible &&
                isProceedToCkeckoutButtonVisible &&
                isBookTumbnailVisible;
        }

        public int GetItemsCount()
        {
            string countContainerContent = GetElementText(basketCount);
            int count = GetFirstNumberOccurence(countContainerContent);

            return count;
        }

        public string GetLabelTitle()
        {
            return GetElementText(confirmationLabel).Trim();
        }

        public string GetProductTitle()
        {
            return GetElementText(productTitle).Trim();
        }

        public double GetProductPrice()
        {
            string priceText = GetElementText(productPrice);
            double price = ParcePrice(priceText);

            return price;
        }

        public double GetTotalPrice()
        {
            string priceText = GetElementText(totalPrice);
            double price = ParcePrice(priceText);

            return price;
        }

        public int GetQuantity()
        {
            string quantityAsText = GetElementText(quantity);

            return int.Parse(quantityAsText);
        }

        public string GetFormat()
        {
            string format = GetElementText(productFormat).Trim(new char[] { ' ', '\"' });

            return format;
        }

        public Book GetFoundBook(int position)
        {
            Format foundItemFormat;
            Enum.TryParse(GetFormat(), out foundItemFormat);

            return new Book
            {
                Title = GetProductTitle(),
                Price = GetProductPrice(),
                Badge = false,
                Format = foundItemFormat
            };
        }

        public void EditBasket()
        {
            Click(editBasketButton);
        }
    }
}
