using Tigerspike.QA.POM.Core.Driver;
using Tigerspike.QA.POM.Core.Pages;
using Tigerspike.QA.POM.Core.Pages.Base;

namespace Tigerspike.QA.POM.Tests.Base
{
    public abstract class BaseTest : DriverSettings
    {
        public HomePage OpenHomePage()
        {
            WebDriver.Navigate().GoToUrl(TestWebsiteUrl);
            return WebBasePage.GetInstance<HomePage>(WebDriver);
        }
    }
}
