using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTaskAmazon.Pages
{
    public class BookDetailsPage : BasePage
    {
        public BookDetailsPage(IWebDriver driver, IWait<IWebDriver> wait) : base(driver, wait)
        {
        }

        public override bool IsAt()
        {
            throw new NotImplementedException();
        }
    }
}
