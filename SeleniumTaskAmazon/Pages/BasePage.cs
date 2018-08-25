using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTaskAmazon.Helpers;
using System;
using System.Configuration;
using Xunit;

namespace SeleniumTaskAmazon.Pages
{
    public abstract class BasePage
    {
        private IWebDriver driver;
        private IWait<IWebDriver> wait;
        private readonly string BaseUrl;

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            this.wait = WaitManager.GetDefaultWait(this.driver);
            BaseUrl = ConfigurationManager.AppSettings.Get("url");
        }

        public IWebDriver Driver
        {
            get { return this.driver; }
            private set
            {
                if (value == null)
                {
                    //TODO: Log Error
                    throw new ArgumentNullException("Driver can not be null!");
                }
            }
        }

        public IWait<IWebDriver> Wait
        {
            get { return this.wait; }
        }


        public abstract bool IsAt();

        public void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(BaseUrl + url);
        }
        
        public void SendKeys(By by, string valueToType)
        {
            try
            {
                Wait.Until(d => d.FindElement(by).Displayed);
                Driver.FindElement(by).Clear();
                Driver.FindElement(by).SendKeys(valueToType);
            }
            catch (NoSuchElementException ex)
            {
                //TODO: Log Error
                Assert.True(false, "NoSuchElementException - Failed to send text to element!");
            }
            catch (WebDriverTimeoutException ex)
            {
                //TODO: Log Error
                Assert.True(false, "WebDriverTimeoutException - Failed to send text to element!");
            }
            catch (StaleElementReferenceException ex)
            {
                // find element again and retry
                Wait.Until(d => d.FindElement(by).Displayed);
                Driver.FindElement(by).Clear();
                Driver.FindElement(by).SendKeys(valueToType);
            }
        }
        
        public void Click(By by)
        {
            try
            {
                Wait.Until(d => d.FindElement(by).Displayed);
                Driver.FindElement(by).Click();
            }
            catch (NoSuchElementException ex)
            {
                //TODO: Log Error
                Assert.True(false, "NoSuchElementException - Failed to send text to element!");
            }
            catch (WebDriverTimeoutException ex)
            {
                //TODO: Log Error
                Assert.True(false, "WebDriverTimeoutException - Failed to send text to element!");
            }
            catch (StaleElementReferenceException ex)
            {
                // find element again and retry
                Wait.Until(d => d.FindElement(by).Displayed);
                Driver.FindElement(by).Click();
            }
        }
        
        public bool CheckElementIsVisible(By by)
        {
            try
            {
                Wait.Until(d => d.FindElement(by).Displayed);
            }
            catch (NoSuchElementException ex)
            {
                //TODO: Log Error
                Assert.True(false, "NoSuchElementException!");
            }
            catch (WebDriverTimeoutException ex)
            {
                //TODO: Log Error
                Assert.True(false, "WebDriverTimeoutException - Failed to verify if element is visible!");
            }
            catch (StaleElementReferenceException ex)
            {
                // find element again and retry
                Wait.Until(d => d.FindElement(by).Displayed);
            }

            return true;
        }
        
        public string GetElementText(By by)
        {
            string returnValue = "";

            try
            {
                Wait.Until(d => d.FindElement(by).Displayed);
                returnValue = Driver.FindElement(by).Text;
            }
            catch (NoSuchElementException ex)
            {
                //TODO: Log Error
                Assert.True(false, "NoSuchElementException - Failed to get text of element!");
            }
            catch (WebDriverTimeoutException ex)
            {
                //TODO: Log Error
                Assert.True(false, "WebDriverTimeoutException - Failed to get text of element!");
            }

            return returnValue;
        }
        
        public string GetElementAttributeValue(By by, string attribute)
        {
            string returnValue = "";

            try
            {
                Wait.Until(d => d.FindElement(by).Displayed);
                returnValue = Driver.FindElement(by).GetAttribute(attribute);
            }
            catch (NoSuchElementException ex)
            {
                //TODO: Log Error
                Assert.True(false, $"NoSuchElementException - Failed to get attribute {attribute} of element!");
            }
            catch (WebDriverTimeoutException ex)
            {
                //TODO: Log Error
                Assert.True(false, $"WebDriverTimeoutException - Failed to get attribute {attribute} of element!");
            }

            return returnValue;
        }

        public void Dispose()
        {
            if(Driver != null)
            {
                Driver.Close();
                Driver.Quit();
                Driver.Dispose();
            }
        }


    }
}
