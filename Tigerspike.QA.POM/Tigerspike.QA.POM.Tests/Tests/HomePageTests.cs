using NUnit.Framework;
using Tigerspike.QA.POM.Tests.Base;

namespace Tigerspike.QA.POM.Tests
{
    public class HomePageTests : BaseTest
    {
        [Test]
        public void OpenCareersPage()
        {
            var homePage = OpenHomePage();
            homePage.NavigateToCareersPage();
        }
    }
}
