using OpenQA.Selenium;
using System;

namespace SeleniumTaskAmazon.Pages
{
    public class HomePage : BasePage
    {
        private const string Title = "Amazon.co.uk: Low Prices in Electronics, Books, Sports Equipment & more";
        private const string expectedUrl = "amazon.co.uk";
        private By footer = By.Id("navFooter");
        private By logo = By.Id("nav-logo");
        private By searchButton = By.XPath("//input[@value='Go']");
        private By searchField = By.Id("twotabsearchtextbox");
        private By searchDropdown = By.Id("searchDropdownBox");
        private By cart = By.Id("nav-cart-count");


        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public override bool IsAt()
        {
            bool isUrlCorrect = Driver.Url.Contains(expectedUrl);
            bool isTitleCorrect = Driver.Title == Title;
            bool isLogoVisible = CheckElementIsVisible(logo);
            bool isCartVisible = CheckElementIsVisible(cart);
            bool isFooterVisible = CheckElementIsVisible(footer);

            return isUrlCorrect && isTitleCorrect && isLogoVisible && isCartVisible && isFooterVisible;
        }

        public void NavigateTo()
        {
            NavigateTo("/");
        }
    }
}
