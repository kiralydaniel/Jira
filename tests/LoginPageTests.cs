using Jira.Main.PageFactory;
using NUnit.Framework;

namespace Jira.Tests
{
    [TestFixture]
    public class LoginPageTests
    {
        private LoginPage loginPage;
        private ProfilePage profilePage;
        private DashboardPage dashboardPage;

        static string EXPECTED_ERROR_MSG = "Sorry, your username and password are incorrect - please try again.";
        static string EXPECTED_LOGOUT_MSG = "You are now logged out. Any automatic login has also been stopped.";

        [SetUp]
        public void Init()
        {
            loginPage = new LoginPage();
            dashboardPage = new DashboardPage();
            profilePage = new ProfilePage();
            loginPage.NavigateTo(Util.BaseURL);
        }
        [Test]
        public void ValidLogin()
        {
            loginPage.LoggingIn(Util.Username, Util.Password);
            dashboardPage.NavigateProfilePage();
            Assert.That(Util.Username, Is.EqualTo(profilePage.GetUsername()));
            dashboardPage.Logout();
        }
        [Test]
        public void EmptyFieldLogin()
        {
            loginPage.LoggingIn("", "");
            Assert.That(EXPECTED_ERROR_MSG, Is.EqualTo(loginPage.GetErrorMessage()));
        }

        [Test]
        public void LogoutAfterSuccessfulLogin()
        {
            loginPage.LoggingIn(Util.Username, Util.Password);
            DashboardPage dashboardPage = new DashboardPage();
            dashboardPage.Logout();
            Assert.That(EXPECTED_LOGOUT_MSG, Is.EqualTo(loginPage.GetLogoutMessage()));
        }

        [TearDown]
        public void Cleanup()
        {
            BasePage.Shutdown();
        }
    }
}