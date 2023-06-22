using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Jira.main.pageFactory
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        string browserType = Environment.GetEnvironmentVariable("browserType");

        public BasePage()
        {
            if (browserType == null)
            {
                browserType = "Chrome";
            }
            driver = WebDriverFactory.CreateWebDriver(browserType);
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
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