using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tigerspike.QA.POM.Core.Pages.Base;
using Tigerspike.QA.POM.Core.Extensions;

namespace Tigerspike.QA.POM.Core.Pages
{
    public class HomePage : WebBasePage
    {
        [FindsBy(How = How.Id, Using = "mhitem-mms4")]
        public IWebElement CareersTab { get; set; }

        public CareersPage NavigateToCareersPage()
        {
            CareersTab.ClickAndWait(2);
            return GetInstance<CareersPage>(WebDriver);
        }
    }
}
