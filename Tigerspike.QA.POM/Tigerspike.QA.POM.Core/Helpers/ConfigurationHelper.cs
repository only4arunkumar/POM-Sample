using System;
using System.Configuration;

namespace Tigerspike.QA.POM.Core.Helpers
{
    public static class ConfigurationHelper
    {
        public static string TestWebsiteUrl
        {
            get
            {
                var testWebsiteUrl = ConfigurationManager.AppSettings["TestWebsiteUrl"];
                if (!String.IsNullOrEmpty(testWebsiteUrl))
                {
                    return testWebsiteUrl;
                }

                return "Enter a default URL";
            }
        }

        public static int DefaultWaitTimeout
        {
            get
            {
                var waitTimeout = 5;
                int.TryParse(ConfigurationManager.AppSettings["DefaultWaitTimeout"], out waitTimeout);

                return waitTimeout;
            }
        }

        public static int DefaultPageLoadTimeout
        {
            get
            {
                var waitTimeout = 10;
                int.TryParse(ConfigurationManager.AppSettings["DefaultPageLoadTimeout"], out waitTimeout);

                return waitTimeout;
            }
        }

        public static int DefaultCommandTimeout
        {
            get
            {
                var waitTimeout = 5;
                int.TryParse(ConfigurationManager.AppSettings["DefaultCommandTimeout"], out waitTimeout);

                return waitTimeout;
            }
        }

        public static string WebDriver
        {
            get
            {
                var webDriver = ConfigurationManager.AppSettings["WebDriver"];
                if (!String.IsNullOrEmpty(webDriver))
                {
                    return webDriver;
                }

                return "FireFox";
            }
        }

        public static string ChromWebDriverPath
        {
            get { return ConfigurationManager.AppSettings["ChromWebDriverPath"]; }
        }

        public static string IeWebDriverPath
        {
            get { return ConfigurationManager.AppSettings["IEWebDriverPath"]; }
        }
    }
}
