using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira.main.pageFactory
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
