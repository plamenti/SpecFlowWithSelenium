using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTaskAmazon.Pages.PageSections
{
    public class FooterSection : BasePage
    {

        private By footer = By.Id("navFooter");
        private By presentationSection = By.XPath("//div[@role='presentation']");
        private By moreOnAmazonSection = By.XPath("//table[@class='navFooterMoreOnAmazon']");

        public FooterSection(IWebDriver driver, IWait<IWebDriver> wait) : base(driver, wait)
        {
        }

        public override bool IsAt()
        {
            bool isFooterVisible = CheckElementIsVisible(footer);
            bool isPresentationSectionVisible = CheckElementIsVisible(presentationSection);
            bool isMoreOnAmazonSectionVisible = CheckElementIsVisible(moreOnAmazonSection);

            return isFooterVisible && isPresentationSectionVisible && isMoreOnAmazonSectionVisible;
        }
    }
}
