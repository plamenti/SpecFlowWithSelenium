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
            }
            catch (AssertionException)
            {
                extentTest.Fail("Failure occurred when executing check '" + reportingMessage + "'", MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenShotsManager.CreateScreenshot(driver)).Build());
                throw;
            }
        }

        public static void AreEqual(IWebDriver driver, ExtentTest extentTest, string expectedValue, string actualValue, string reportingMessage)
        {
            try
            {
                Assert.AreEqual(expectedValue, actualValue);
                extentTest.Pass(reportingMessage);
            }
            catch (AssertionException)
            {
                if (driver != null)
                {
                    extentTest.Fail("Failure occurred when executing check '" + reportingMessage + "'", MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenShotsManager.CreateScreenshot(driver)).Build());
                }
                else
                {
                    extentTest.Fail("Failure occurred when executing check '" + reportingMessage + "'");
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
            }
            catch (AssertionException)
            {
                if (driver != null)
                {
                    extentTest.Fail("Failure occurred when executing check '" + reportingMessage + "', actual value was " + actualValue, MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenShotsManager.CreateScreenshot(driver)).Build());
                }
                else
                {
                    extentTest.Fail("Failure occurred when executing check '" + reportingMessage + "', actual value was " + actualValue);
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
            }
            catch (AssertionException)
            {
                if (driver != null)
                {
                    extentTest.Fail("Failure occurred when executing check '" + reportingMessage + "', actual value was " + actualValue, MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenShotsManager.CreateScreenshot(driver)).Build());
                }
                else
                {
                    extentTest.Fail("Failure occurred when executing check '" + reportingMessage + "', actual value was " + actualValue);
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
            }
            catch (AssertionException)
            {
                if (driver != null)
                {
                    extentTest.Fail("Failure occurred when executing check '" + reportingMessage + "', actual value was " + actualValue, MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenShotsManager.CreateScreenshot(driver)).Build());
                }
                else
                {
                    extentTest.Fail("Failure occurred when executing check '" + reportingMessage + "', actual value was " + actualValue);
                }
                throw;
            }
        }
    }
}
