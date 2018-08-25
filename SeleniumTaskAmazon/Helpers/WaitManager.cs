﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;

namespace SeleniumTaskAmazon.Helpers
{
    public class WaitManager
    {
        private const int DefaultTimeoutTime = 5000;

        public static IWait<IWebDriver> GetDefaultWait(IWebDriver driver)
        {
            string timeoutAsString = ConfigurationManager.AppSettings.Get("timeout").ToLower();
            int timeout;
            if(!int.TryParse(timeoutAsString, out timeout))
            {
                timeout = DefaultTimeoutTime;
            }

            if (driver == null)
            {
                //TODO: Log Error
                throw new ArgumentNullException("Driver used in Wait can not be null!");
            }

            return new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
        }
    }
}