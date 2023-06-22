using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Jira.main.pageFactory
{
    public class WebDriverFactory
    {
        private static IWebDriver webDriver = null;

        public static IWebDriver CreateWebDriver(string browserType)
        {
            if (webDriver == null)
            {
                switch (browserType)
                {
                    case "Chrome":
                        webDriver = new ChromeDriver();
                        break;
                    case "Firefox":
                        webDriver = new FirefoxDriver();
                        break;
                }
            }

            return webDriver;
        }

        public static void ShutdownWebDriver()
        {
            webDriver.Quit();
            webDriver = null;
            
        }
    }

}