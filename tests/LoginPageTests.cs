using Jira.main.pageFactory;
using NUnit.Framework;

namespace Jira.tests
{
    [TestFixture]
    public class LoginPageTests
    {
        private LoginPage loginPage;
        static string EXPECTED_ERROR_MSG = "Sorry, your username and password are incorrect - please try again.";
        static string EXPECTED_LOGOUT_MSG = "You are now logged out. Any automatic login has also been stopped.";

        [SetUp]
        public void Init()
        {
            loginPage = new LoginPage();
            loginPage.NavigateTo(Util.baseURL);
        }
        [Test]
        public void ValidLogin()
        {
            loginPage.LoggingIn(Util.username, Util.password);
            DashboardPage dashboardPage = new DashboardPage();
            ProfilePage profilePage = new ProfilePage();
            dashboardPage.NavigateProfilePage();
            Assert.That(Util.username, Is.EqualTo(profilePage.GetUsername()));
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
            loginPage.LoggingIn(Util.username, Util.password);
            DashboardPage dashboardPage = new DashboardPage();
            dashboardPage.Logout();
            Assert.That(EXPECTED_LOGOUT_MSG, Is.EqualTo(loginPage.GetLogoutMessage()));
        }

        [TearDown]
        public void Cleanup()
        {
            BasePage.Teardown();
        }
    }
}