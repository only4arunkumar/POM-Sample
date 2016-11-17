using NUnit.Framework;
using Tigerspike.QA.POM.Tests.Base;

namespace Tigerspike.QA.POM.Tests
{
    public class CareersPageTests : BaseTest
    {
        [Test]
        public void OpenHomePageFromCareers()
        {
            var homePage = OpenHomePage();
            var careersPage = homePage.NavigateToCareersPage();
            careersPage.NavigateToHomePage();
        }
    }
}
