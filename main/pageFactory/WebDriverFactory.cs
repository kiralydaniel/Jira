using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Jira.Main.PageFactory
{
    public class WebDriverFactory
    {
        private static IWebDriver webDriver = null;
        private static readonly string gridUrl = Util.GridURL;

        public static IWebDriver CreateWebDriver(string browserType, bool isRemote)
        {
            if (webDriver == null)
            {
                if (!isRemote)
                {
                    switch (browserType)
                    {
                        case "chrome":
                            webDriver = new ChromeDriver();
                            break;
                        case "firefox":
                            webDriver = new FirefoxDriver();
                            break;
                    }
                }
                else
                {  
                    if (browserType.Equals("chrome", StringComparison.OrdinalIgnoreCase))
                    {
                        ChromeOptions chromeOptions = new ChromeOptions();
                        webDriver = new RemoteWebDriver(new Uri(gridUrl), chromeOptions);
                    }
                    else if (browserType.Equals("firefox", StringComparison.OrdinalIgnoreCase))
                    {
                        FirefoxOptions firefoxOptions = new FirefoxOptions();
                        webDriver = new RemoteWebDriver(new Uri(gridUrl), firefoxOptions);
                    }
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