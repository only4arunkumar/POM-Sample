using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tigerspike.QA.POM.Core.Extensions;

namespace Tigerspike.QA.POM.Core.Pages.Base
{
    public abstract class WebBasePage
    {
        protected IWebDriver WebDriver { get; set; }

        protected string ExpectedTitle { get; set; }

        /// <summary>
        /// Gets the instance
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <param name="webDriver"></param>
        /// <param name="expectedTitle"></param>
        /// <returns></returns>
        public static TPage GetInstance<TPage>(IWebDriver webDriver, string expectedTitle = "") where TPage : WebBasePage, new()
        {
            var pageInstance = new TPage()
            {
                ExpectedTitle = expectedTitle,
                WebDriver = webDriver
            };

            PageFactory.InitElements(webDriver, pageInstance);

            webDriver.WaitForPageToLoad();

            if (!String.IsNullOrEmpty(expectedTitle)) // check page title if exist
            {
            }

            return pageInstance;
        }
    }
}
