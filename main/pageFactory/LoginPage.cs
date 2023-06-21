using OpenQA.Selenium;


namespace Jira.main.pageFactory
{
    public class LoginPage : BasePage
    {

        private readonly By usernameLocator = By.Id("login-form-username");
        private readonly By passwordLocator = By.Id("login-form-password");
        private readonly By loginBtnLocator = By.Id("login");
        private readonly By errorMsgLocator = By.Id("usernameerror");
        private readonly By logoutMsgLocator = By.XPath("//*[@id='main']/div/div/p[1]/strong");

        private IWebElement username;
        private IWebElement password;
        private IWebElement loginBtn;
        private IWebElement errorMsg;
        private IWebElement logoutMsg;


        public LoginPage() : base()
        {
        }


        public void EnterUsername(string usernameText)
        {
            username = driver.FindElement(usernameLocator);
            username.SendKeys(usernameText);
        }

        public void EnterPassword(string passwordText)
        {
            password = driver.FindElement(passwordLocator);
            password.SendKeys(passwordText);
        }

        public void ClickLoginButton()
        {
            loginBtn = driver.FindElement(loginBtnLocator);
            loginBtn.Click();
        }

        public void loggingIn(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLoginButton();
        }

        public string GetErrorMessage()
        {
            errorMsg = driver.FindElement(errorMsgLocator);
            return errorMsg.Text;
        }

        public string GetLogoutMessage()
        {
            logoutMsg = driver.FindElement(logoutMsgLocator);
            return logoutMsg.Text;
        }

    }
}