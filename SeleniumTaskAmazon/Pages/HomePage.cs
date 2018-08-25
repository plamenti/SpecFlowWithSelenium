using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;

namespace SeleniumTaskAmazon.Pages
{
    public class HomePage : BasePage
    {
        private readonly string baseUrl = ConfigurationManager.AppSettings.Get("url");
          
        private By logo = By.Id("nav-logo");
        private By cart = By.Id("nav-cart-count");
        private By footer = By.Id("navFooter");
        private By searchButton = By.XPath("//input[@value='Go']");
        private By searchField = By.Id("twotabsearchtextbox");
        private By searchDropdown = By.Id("searchDropdownBox");
        private By helloGreeting = By.XPath("//a[@id='nav-link-yourAccount']/span[@class='nav-line-1']");

        public HomePage(IWebDriver driver, IWait<IWebDriver> wait) : base(driver, wait)
        {
        }

        public string getTitle()
        {
            return driver.Title;
        }

        public string getCurrentUrl()
        {
            return driver.Url;
        }

        public bool isLoggedInAs(string username)
        {
            string greetingLabel = GetElementText(helloGreeting);
            return greetingLabel.Contains(username);
        }


        public bool canSearch()
        {
            bool isSearchFieldVisible = CheckElementIsVisible(searchField);
            bool issearchButtonVisible = CheckElementIsVisible(searchButton);

            return isSearchFieldVisible && issearchButtonVisible;
        }

        public override void NavigateTo()
        {
            driver.Navigate().GoToUrl(baseUrl);
        }

        public override bool IsAt()
        {
            bool isLogoVisible = CheckElementIsVisible(logo);
            bool isCartVisible = CheckElementIsVisible(cart);
            bool isFooterVisible = CheckElementIsVisible(footer);

            return isLogoVisible && isCartVisible && isFooterVisible;
        }
    }
}
