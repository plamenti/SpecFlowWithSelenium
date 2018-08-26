using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTaskAmazon.Pages
{
    public class BasketPage : BasePage
    {
        public BasketPage(IWebDriver driver, IWait<IWebDriver> wait) : base(driver, wait)
        {
        }

        public override bool IsAt()
        {
            throw new NotImplementedException();
        }
    }
}
