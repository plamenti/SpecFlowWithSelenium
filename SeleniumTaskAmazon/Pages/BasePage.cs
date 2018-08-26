using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace SeleniumTaskAmazon.Pages
{
    public abstract class BasePage
    {
        private IWait<IWebDriver> wait;
        protected IWebDriver driver;

        public BasePage(IWebDriver driver, IWait<IWebDriver> wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public abstract bool IsAt();

        public IWebElement GetElement(By by)
        {
            try
            {
                wait.Until(d => d.FindElement(by).Enabled);
            }
            catch (NoSuchElementException ex)
            {
                //TODO: Log Error in Logger
                Assert.True(false, "NoSuchElementException - Failed to find elements!");
            }
            catch (WebDriverTimeoutException ex)
            {
                //TODO: Log Error in Logger
                Assert.True(false, "WebDriverTimeoutException - Failed to find elements!");
            }
            catch (StaleElementReferenceException ex)
            {
                wait.Until(d => d.FindElement(by).Enabled);

                return driver.FindElement(by);
            }

            return driver.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> GetElements(By by)
        {
            try
            {
                wait.Until(d => d.FindElements(by).Count > 0);
            }
            catch (NoSuchElementException ex)
            {
                //TODO: Log Error in Logger
                Assert.True(false, "NoSuchElementException - Failed to find elements!");
            }
            catch (WebDriverTimeoutException ex)
            {
                //TODO: Log Error in Logger
                Assert.True(false, "WebDriverTimeoutException - Failed to find elements!");
            }
            catch (StaleElementReferenceException ex)
            {
                wait.Until(d => d.FindElements(by).Count > 0);

                return driver.FindElements(by);
            }

            return driver.FindElements(by);
        }

        public void SendKeys(By by, string valueToType)
        {
            try
            {
                wait.Until(d => d.FindElement(by).Displayed);
                driver.FindElement(by).Clear();
                driver.FindElement(by).SendKeys(valueToType);
            }
            catch (NoSuchElementException ex)
            {
                //TODO: Log Error in Logger
                Assert.True(false, "NoSuchElementException - Failed to send text to element!");
            }
            catch (WebDriverTimeoutException ex)
            {
                //TODO: Log Error in Logger
                Assert.True(false, "WebDriverTimeoutException - Failed to send text to element!");
            }
            catch (StaleElementReferenceException ex)
            {
                wait.Until(d => d.FindElement(by).Displayed);
                driver.FindElement(by).Clear();
                driver.FindElement(by).SendKeys(valueToType);
            }
        }

        public void Click(By by)
        {
            try
            {
                wait.Until(d => d.FindElement(by).Displayed);
                driver.FindElement(by).Click();
            }
            catch (NoSuchElementException ex)
            {
                //TODO: Log Error in Logger
                Assert.True(false, "NoSuchElementException - Failed to send text to element!");
            }
            catch (WebDriverTimeoutException ex)
            {
                //TODO: Log Error in Logger
                Assert.True(false, "WebDriverTimeoutException - Failed to send text to element!");
            }
            catch (StaleElementReferenceException ex)
            {
                // find element again and retry
                wait.Until(d => d.FindElement(by).Displayed);
                driver.FindElement(by).Click();
            }
        }

        public bool CheckElementIsVisible(By by)
        {
            try
            {
                wait.Until(d => d.FindElement(by).Displayed);
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
            catch (WebDriverTimeoutException ex)
            {
                return false;
            }
            catch (StaleElementReferenceException ex)
            {
                wait.Until(d => d.FindElement(by).Displayed);
            }

            return true;
        }

        public string GetElementText(By by)
        {
            string returnValue = "";

            try
            {
                wait.Until(d => d.FindElement(by).Displayed);
                returnValue = driver.FindElement(by).Text;
            }
            catch (NoSuchElementException ex)
            {
                //TODO: Log Error in Logger
                Assert.True(false, "NoSuchElementException - Failed to get text of element!");
            }
            catch (WebDriverTimeoutException ex)
            {
                //TODO: Log Error in Logger
                Assert.True(false, "WebDriverTimeoutException - Failed to get text of element!");
            }

            return returnValue;
        }

        public string GetElementAttributeValue(By by, string attribute)
        {
            string returnValue = "";

            try
            {
                wait.Until(d => d.FindElement(by).Displayed);
                returnValue = driver.FindElement(by).GetAttribute(attribute);
            }
            catch (NoSuchElementException ex)
            {
                //TODO: Log Error in Logger
                Assert.True(false, $"NoSuchElementException - Failed to get attribute {attribute} of element!");
            }
            catch (WebDriverTimeoutException ex)
            {
                //TODO: Log Error in Logger
                Assert.True(false, $"WebDriverTimeoutException - Failed to get attribute {attribute} of element!");
            }

            return returnValue;
        }

        public void SelectElementFromDrodownByText(By by, string elementTextValue)
        {
            try
            {
                wait.Until(d => d.FindElement(by).Enabled);
                IWebElement select = driver.FindElement(by);
                var selectElement = new SelectElement(select);
                selectElement.SelectByText(elementTextValue);
            }
            catch (NoSuchElementException ex)
            {
                //TODO: Log Error in Logger
                Assert.True(false, "NoSuchElementException - Failed to find select element!");
            }
            catch (WebDriverTimeoutException ex)
            {
                //TODO: Log Error in Logger
                Assert.True(false, "WebDriverTimeoutException - Failed to find select element!");
            }
            catch (StaleElementReferenceException ex)
            {
                wait.Until(d => d.FindElement(by).Enabled);
                IWebElement select = driver.FindElement(by);
                var selectElement = new SelectElement(select);
                selectElement.SelectByText(elementTextValue);
            }
        }

        protected void HoverOverElement(By by)
        {
            IWebElement element = GetElement(by);

            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }

        protected int GetFirstNumberOccurence(string text)
        {
            Regex regex = new Regex(@"\d+");
            Match match = regex.Match(text);
            int result = -1;

            if (match.Success)
            {
                int.TryParse(match.Value, out result);
            }

            return result;
        }

        protected double ParcePrice(string text)
        {
            Regex regex = new Regex(@"[-+]?[0-9]*\.?[0-9]+");
            Match match = regex.Match(text);
            double result = -1.0;

            if (match.Success)
            {
                double.TryParse(match.Value, out result);
            }

            return result;
        }
    }
}
