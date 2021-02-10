using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace specflowselenium.Utils
{
    /// <summary>
    /// WebDriver utlities class for common helper methods.
    /// </summary>
    public static class WebDriverUtilities
    {
        /// <summary>
        /// Helper method to wait until element is found.
        /// </summary>
        /// <param name="driver">Selenium web driver.</param>
        /// <param name="by">element to be found using by</param>
        /// <param name="timeoutInSeconds">time out in seconds</param>
        /// <returns>Element found result with timeout.</returns>
        public static IWebElement FindElement(IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }

            return driver.FindElement(by);
        }
    }
}
