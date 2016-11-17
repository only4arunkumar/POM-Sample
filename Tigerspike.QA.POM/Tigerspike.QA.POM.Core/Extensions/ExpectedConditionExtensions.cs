using System;
using OpenQA.Selenium;

namespace Tigerspike.QA.POM.Core.Extensions
{
    public static class ExpectedConditionExtensions
    {
        /// <summary>
        /// Checks weather element is clickable - with the exact element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private static IWebElement ElementIsClickable(IWebElement element)
        {
            if (element.Displayed && element.Enabled)
            {
                return element;
            }

            return null;
        }

        /// <summary>
        /// Checks weather element is clickable - with Func
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public static Func<IWebDriver, IWebElement> ElementIsClickable(By locator)
        {
            return webDriver =>
            {
                try
                {
                    return ElementIsClickable(webDriver.FindElement(locator));
                }
                catch
                {
                    return null;
                }
            };
        }
    }
}
