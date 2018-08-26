﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
        private By bookTitle = By.XPath("//div[@id='mdp-title']//span[contains(@class, 'product-title')]");

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
            throw new NotImplementedException();
        }

        public string GetLabelTitle()
        {
            return GetElementText(confirmationLabel).Trim();
        }
    }
}
