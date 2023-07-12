using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Jira.Main.PageFactory
{
    public class ProfilePage : BasePage
    {
        private readonly By usernameLocator = By.Id("up-d-username");

        private IWebElement username;

        public ProfilePage() : base() 
        { 
        }

        public string GetUsername()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(usernameLocator));
            username = driver.FindElement(usernameLocator);
            return username.Text;
        }

    }
}
