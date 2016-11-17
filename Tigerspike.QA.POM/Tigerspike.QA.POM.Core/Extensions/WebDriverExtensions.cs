using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Tigerspike.QA.POM.Core.Helpers;

namespace Tigerspike.QA.POM.Core.Extensions
{
    public static class WebDriverExtensions
    {

        /// <summary>
        /// Extension for FindElements method with time as a parameter
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        public static IWebElement FindElementSafe(this IWebDriver driver, By by, int timeoutInSeconds = 0)
        {
            try
            {
                if (timeoutInSeconds <= 0)
                {
                    timeoutInSeconds = ConfigurationHelper.DefaultWaitTimeout;
                }

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

                return wait.Until(ExpectedConditionExtensions.ElementIsClickable(by));
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Waits for page to load
        /// </summary>
        /// <param name="webDriver"></param>
        public static void WaitForPageToLoad(this IWebDriver webDriver)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(ConfigurationHelper.DefaultPageLoadTimeout));

            var javascript = webDriver as IJavaScriptExecutor;
            if (javascript == null)
            {
                throw new ArgumentException("WebDriver must support javascript execution", "webDriver");
            }

            wait.Until(d =>
            {
                try
                {
                    string readyState = javascript.ExecuteScript("if (document.readyState) return document.readyState;").ToString();

                    return readyState.ToLower() == "complete";
                }
                catch (InvalidOperationException e)
                {
                    //Window is no longer available
                    return e.Message.ToLower().Contains("unable to get browser");
                }
                catch (WebDriverException e)
                {
                    //Browser is no longer available
                    return e.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }
    }
}
