using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Threading;
using Tigerspike.QA.POM.Core.Helpers;

namespace Tigerspike.QA.POM.Core.Driver
{
    public abstract class DriverSettings
    {
        protected string TestWebsiteUrl { get; set; }

        protected DriverSettings()
        {
            TestWebsiteUrl = ConfigurationHelper.TestWebsiteUrl;
        }

        protected IWebDriver WebDriver { get; set; }

        [SetUp]
        public virtual void SetUp()
        {
            var webDriver = ConfigurationHelper.WebDriver;
            var timeOuts = TimeSpan.FromMinutes(ConfigurationHelper.DefaultCommandTimeout);

            switch (webDriver)
            {
                case "FireFox":
                    {
                        //Firefox will not work with Selenium 3

                        WebDriver = new FirefoxDriver();

                        break;
                    }

                case "IE":
                    {
                        var iEOptions = new InternetExplorerOptions();
                        WebDriver = new InternetExplorerDriver(ConfigurationHelper.IeWebDriverPath, iEOptions, timeOuts);

                        break;
                    }

                case "Chrome":
                    {
                        var chromeOptions = new ChromeOptions();
                        chromeOptions.AddExcludedArgument("ignore-certifcate-errors");
                        chromeOptions.AddArgument("test-type");

                        WebDriver = new ChromeDriver(ConfigurationHelper.ChromWebDriverPath, chromeOptions, timeOuts);

                        break;
                    }

                default:
                    {
                        throw new Exception("Not found web driver");
                    }

            }

            WebDriver.Manage().Window.Maximize();
        }

        [TearDown]
        public virtual void TearDown()
        {
            Thread.Sleep(1000); // wait before closing the web driver

            WebDriver.Quit();
        }
    }
}
