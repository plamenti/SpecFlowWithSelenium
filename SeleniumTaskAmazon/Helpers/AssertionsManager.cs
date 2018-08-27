using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumTaskAmazon.Helpers
{
    public class AssertionsManager
    {
        public static void IsTrue(IWebDriver driver, ExtentTest extentTest, bool assertedValue, string reportingMessage)
        {
            try
            {
                Assert.IsTrue(assertedValue);
                extentTest.Pass(reportingMessage);
                LoggingManager.LogInfo(reportingMessage);
            }
            catch (AssertionException)
            {
                string errorMessage = "Failure occurred when executing check '" + reportingMessage + "'";
                extentTest.Fail(errorMessage, MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenShotsManager.CreateScreenshot(driver)).Build());
                LoggingManager.LogError(errorMessage);
                throw;
            }
        }

        public static void AreEqual(IWebDriver driver, ExtentTest extentTest, string expectedValue, string actualValue, string reportingMessage)
        {
            try
            {
                Assert.AreEqual(expectedValue, actualValue);
                extentTest.Pass(reportingMessage);
                LoggingManager.LogInfo(reportingMessage);
            }
            catch (AssertionException)
            {
                string errorMessage = "Failure occurred when executing check '" + reportingMessage + "'";

                if (driver != null)
                {
                    extentTest.Fail(errorMessage, MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenShotsManager.CreateScreenshot(driver)).Build());
                    LoggingManager.LogError(errorMessage);
                }
                else
                {
                    extentTest.Fail(errorMessage);
                    LoggingManager.LogError(errorMessage);
                }
                throw;
            }
        }

        public static void AreEqual(IWebDriver driver, ExtentTest extentTest, int expectedValue, int actualValue, string reportingMessage)
        {
            try
            {
                Assert.AreEqual(expectedValue, actualValue);
                extentTest.Pass(reportingMessage);
                LoggingManager.LogInfo(reportingMessage);
            }
            catch (AssertionException)
            {
                string errorMessage = "Failure occurred when executing check '" + reportingMessage + "', actual value was " + actualValue;

                if (driver != null)
                {
                    extentTest.Fail(errorMessage, MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenShotsManager.CreateScreenshot(driver)).Build());
                    LoggingManager.LogError(errorMessage);
                }
                else
                {
                    extentTest.Fail(errorMessage);
                    LoggingManager.LogError(errorMessage);
                }
                throw;
            }
        }

        public static void AreEqual(IWebDriver driver, ExtentTest extentTest, double expectedValue, double actualValue, string reportingMessage)
        {
            try
            {
                Assert.AreEqual(expectedValue, actualValue);
                extentTest.Pass(reportingMessage);
                LoggingManager.LogInfo(reportingMessage);
            }
            catch (AssertionException)
            {
                string errorMessage = "Failure occurred when executing check '" + reportingMessage + "', actual value was " + actualValue;

                if (driver != null)
                {
                    extentTest.Fail(errorMessage, MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenShotsManager.CreateScreenshot(driver)).Build());
                    LoggingManager.LogError(errorMessage);
                }
                else
                {
                    extentTest.Fail("Failure occurred when executing check '" + reportingMessage + "', actual value was " + actualValue);
                    LoggingManager.LogError(errorMessage);
                }
                throw;
            }
        }

        public static void AreEqual(IWebDriver driver, ExtentTest extentTest, object expectedValue, object actualValue, string reportingMessage)
        {
            try
            {
                Assert.AreEqual(expectedValue, actualValue);
                extentTest.Pass(reportingMessage);
                LoggingManager.LogInfo(reportingMessage);
            }
            catch (AssertionException)
            {
                string errorMessage = "Failure occurred when executing check '" + reportingMessage + "', actual value was " + actualValue;

                if (driver != null)
                {
                    extentTest.Fail(errorMessage, MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenShotsManager.CreateScreenshot(driver)).Build());
                    LoggingManager.LogError(errorMessage);
                }
                else
                {
                    extentTest.Fail(errorMessage);
                    LoggingManager.LogError(errorMessage);
                }
                throw;
            }
        }
    }
}
