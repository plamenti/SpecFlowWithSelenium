using OpenQA.Selenium;
using System;
using System.IO;

namespace SeleniumTaskAmazon.Helpers
{
    public class ScreenShotsManager
    {
        public static String CreateScreenshot(IWebDriver driver)
        {
            string uuid = Guid.NewGuid().ToString();
            string fileName = Path.Combine(IOManager.CreateImagesDirectory(), uuid) + ".png";

            Screenshot screen = ((ITakesScreenshot)driver).GetScreenshot();
            screen.SaveAsFile(fileName, ScreenshotImageFormat.Png);

            return fileName;
        }
    }
}
