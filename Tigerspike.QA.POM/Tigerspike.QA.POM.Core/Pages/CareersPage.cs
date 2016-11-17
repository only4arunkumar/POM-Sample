using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tigerspike.QA.POM.Core.Pages.Base;
using Tigerspike.QA.POM.Core.Extensions;

namespace Tigerspike.QA.POM.Core.Pages
{
    public class CareersPage : WebBasePage
    {
        [FindsBy(How = How.Id, Using = "ibm-home")]
        public IWebElement HomePageLogo { get; set; }

        public HomePage NavigateToHomePage()
        {
            HomePageLogo.ClickAndWait(2);
            return GetInstance<HomePage>(WebDriver);
        }
    }
}
