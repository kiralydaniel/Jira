using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Jira.main.pageFactory
{
    public class WebDriverFactory
    {
        private static IWebDriver driver;

        public static IWebDriver CreateWebDriver(string browserType)
        {
            switch (browserType)
            {
                case "Chrome":
                    driver = CreateChromeDriver();
                    break;
                case "Firefox":
                    driver = CreateFirefoxDriver();
                    break;
            }

            driver.Manage().Window.Maximize();

            return driver;
        }

        private static IWebDriver CreateChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            return new ChromeDriver(options);
        }

        private static IWebDriver CreateFirefoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            return new FirefoxDriver(options);
        }

        public static void ShutdownWebDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }

}