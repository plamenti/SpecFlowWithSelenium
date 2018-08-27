using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTaskAmazon.Pages.PageSections;

namespace SeleniumTaskAmazon.Pages
{
    public class HomePage : BasePage
    {
        private HeaderSection header;
        private FooterSection footer;
        private By slidebar = By.Id("sidebar-top");
        private By featuredItemsContainer = By.Id("gw-desktop-herotator");
        private By desktopTopItemsContainer = By.Id("desktop-top");

        public HomePage(IWebDriver driver, IWait<IWebDriver> wait) : base(driver, wait)
        {
            this.header = new HeaderSection(driver, wait);
            this.footer = new FooterSection(driver, wait);
        }

        public string GetTitle()
        {
            return driver.Title;
        }

        public string GetCurrentUrl()
        {
            return driver.Url;
        }

        public void NavigateTo()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }

        public bool IsLoggedInAs(string username)
        {
            return header.IsLoggedInAs(username);
        }

        public bool CanSearch()
        {
            return header.CanSearch();
        }

        public void SelectSearchCategory(string category)
        {
            header.SelectCategory(category);
        }

        public void SearchForItem(string item)
        {
            header.SearchForItem(item);
        }

        public override bool IsAt()
        {
            bool isSlidebarVisible = CheckElementIsVisible(slidebar);
            bool isfeaturedItemsContainerVisible = CheckElementIsVisible(featuredItemsContainer);
            bool isdesktopTopItemsContainerVisible = CheckElementIsVisible(desktopTopItemsContainer);

            return header.IsAt() &&
                footer.IsAt() &&
                isSlidebarVisible &&
                isfeaturedItemsContainerVisible &&
                isdesktopTopItemsContainerVisible;
        }
    }
}
