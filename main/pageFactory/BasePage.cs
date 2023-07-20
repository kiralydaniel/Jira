using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Jira.Main.PageFactory
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        readonly string browserType = Util.BrowserType.ToLower();
        readonly bool isRemote = Util.IsRemote;

        public BasePage()
        {
            if (browserType == null)
            {
                browserType = "chrome";
            }
            driver = WebDriverFactory.CreateWebDriver(browserType, isRemote);
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

        public static void Shutdown()
        {
            WebDriverFactory.ShutdownWebDriver();
        }
    }
}