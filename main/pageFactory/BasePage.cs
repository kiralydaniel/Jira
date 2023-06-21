using Jira.main.pageFactory;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using OpenQA.Selenium;
using System;

namespace Jira.main.pageFactory
{
    public class BasePage
    {
        protected IWebDriver driver;
        string browserType = Environment.GetEnvironmentVariable("browserType");

        public BasePage()
        {
            if (browserType == null)
            {
                browserType = "Chrome";
            }
            this.driver = WebDriverFactory.CreateWebDriver(browserType);
        }

        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void RefreshPage()
        {
            driver.Navigate().Refresh();
        }

        public static void Teardown()
        {
            WebDriverFactory.ShutdownWebDriver();
        }
    }
}