using Jira.Main.PageFactory;
using NUnit.Framework;


namespace Jira.Tests
{
    [TestFixture]
    public class BrowseProjectTests
    {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;
        private ProjectPage projectPage;

        [SetUp]
        public void Init()
        {
            loginPage = new LoginPage();
            projectPage = new ProjectPage();
            dashboardPage = new DashboardPage();
            loginPage.NavigateTo(Util.BaseURL);
            loginPage.LoggingIn(Util.Username, Util.Password);
        }

        private void BrowseProject(string url, string expected)
        {
            dashboardPage.WaitForProfileBtn();
            dashboardPage.NavigateTo(url);
            Assert.That(projectPage.GetKey(), Is.EqualTo(expected));
        }
        [Test]
        [TestCaseSource(typeof(Util), nameof(Util.TestData), new object[] { "Main/Resources/browseProject.csv" })]
        public void BrowseProjectParameterized(string url, string key)
        {
            BrowseProject(url, key);
        }

        [Test]
        public void BrowseProjectWithoutPermission()
        {
            dashboardPage.WaitForProfileBtn();
            dashboardPage.NavigateTo("https://jira-auto.codecool.metastage.net/projects/MTP3/summary");
            Assert.That(projectPage.GetErrorMessage(), Is.EqualTo("You can't view this project"));
        }

        [Test]
        public void BrowseNonExistentProject()
        {
            dashboardPage.WaitForProfileBtn();
            dashboardPage.NavigateTo("https://jira-auto.codecool.metastage.net/projects/MTP2/summary");
            Assert.That(projectPage.GetErrorMessage(), Is.EqualTo("You can't view this project"));
        }

        [TearDown]
        public void Cleanup()
        {
            BasePage.Shutdown();
        }

    }
}
