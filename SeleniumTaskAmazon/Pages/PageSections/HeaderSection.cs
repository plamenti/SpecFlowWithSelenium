using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTaskAmazon.Pages.PageSections
{
    public class HeaderSection : BasePage
    {
        private By logo = By.Id("nav-logo");
        private By cart = By.Id("nav-cart-count");
        private By searchButton = By.XPath("//input[@value='Go']");
        private By searchField = By.Id("twotabsearchtextbox");
        private By searchDropdown = By.Id("searchDropdownBox");
        private By helloGreeting = By.XPath("//a[@id='nav-link-yourAccount']/span[@class='nav-line-1']");

        public HeaderSection(IWebDriver driver, IWait<IWebDriver> wait) : base(driver, wait)
        {
        }

        public bool CanSearch()
        {
            bool isSearchFieldVisible = CheckElementIsVisible(searchField);
            bool issearchButtonVisible = CheckElementIsVisible(searchButton);

            return isSearchFieldVisible && issearchButtonVisible;
        }

        public void SearchForItem(string item)
        {
            SendKeys(searchField, item);
            Click(searchButton);
        }

        public void SelectCategory(string category)
        {
            SelectElementFromDrodownByText(searchDropdown, category);
        }

        public bool IsLoggedInAs(string username)
        {
            string greetingLabel = GetElementText(helloGreeting);
            return greetingLabel.Contains(username);
        }

        public override bool IsAt()
        {
            bool isLogoVisible = CheckElementIsVisible(logo);
            bool isCartVisible = CheckElementIsVisible(cart);

            return isLogoVisible && isCartVisible;
        }
    }
}
