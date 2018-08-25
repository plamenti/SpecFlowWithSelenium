using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTaskAmazon.Helpers;

namespace SeleniumTaskAmazon.Pages
{
    public abstract class BasePage
    {
        private IWebDriver driver;
        private IWait<IWebDriver> wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = WaitManager.GetDefaultWait(this.driver);
        }
    }


}
