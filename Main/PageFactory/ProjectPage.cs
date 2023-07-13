using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Jira.Main.PageFactory
{
    public class ProjectPage : BasePage
    {
        private readonly By keyLocator = By.XPath("//*[@id='summary-body']/div/div[2]/dl/dd[2]");
        private readonly By errorMsgLocator = By.XPath("/html/body/div/div/div/div/main/h1");

        private IWebElement key;
        private IWebElement errorMsg;
        public ProjectPage()
        {
        }
        public string GetKey()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(keyLocator));
            key = driver.FindElement(keyLocator);
            return key.Text;
        }

        public string GetErrorMessage()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(errorMsgLocator));
            errorMsg = driver.FindElement(errorMsgLocator);
            return errorMsg.Text;
        }
    }
}
