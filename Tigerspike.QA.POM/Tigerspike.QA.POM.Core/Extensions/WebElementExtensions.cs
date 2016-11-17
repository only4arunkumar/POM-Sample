using System;
using OpenQA.Selenium;
using System.Text;
using System.Threading;

namespace Tigerspike.QA.POM.Core.Extensions
{
    public static class WebElementExtensions
    {
        /// <summary>
        /// Extension for SendKeys - clears and enters the text
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void ClearAndSendKeys(this IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }

        /// <summary>
        /// Extension for Click - clicks on element and wait for next action
        /// </summary>
        /// <param name="element"></param>
        /// <param name="secondsTimeout"></param>
        public static void ClickAndWait(this IWebElement element, double secondsTimeout = 1)
        {
            element.Click();
            Thread.Sleep(TimeSpan.FromSeconds(secondsTimeout));
        }

        /// <summary>
        /// Extension for SendKeys - enters the text and wait
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        /// <param name="secondsTimeout"></param>
        public static void SendKeysAndWait(this IWebElement element, string value, double secondsTimeout = 5)
        {
            element.SendKeys(value);
            Thread.Sleep(TimeSpan.FromSeconds(secondsTimeout));
        }
    }
}
