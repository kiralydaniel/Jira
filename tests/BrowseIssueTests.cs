using Jira.Main.PageFactory;
using NUnit.Framework;


namespace Jira.Tests
{
    [TestFixture]
    public class BrowseIssueTests
    {
        private LoginPage loginPage;
        private IssuePage issuePage;
        private DashboardPage dashboardPage;

        [SetUp]
        public void Init()
        {
            loginPage = new LoginPage();
            issuePage = new IssuePage();
            dashboardPage = new DashboardPage();
            loginPage.NavigateTo(Util.BaseURL);
            loginPage.LoggingIn(Util.Username, Util.Password);
        }

        private void BrowseIssue(string issueUrl, string expectedIssueKey)
        {
            dashboardPage.WaitForProfileBtn();
            loginPage.NavigateTo(issueUrl);
            Assert.That(expectedIssueKey, Is.EqualTo(issuePage.GetIssueKey()));
        }

        [Test]
        [TestCaseSource(typeof(Util), nameof(Util.TestData), new object[] { "Main/Resources/issues.csv" })]
        public void BrowseIssueTest(string issueUrl, string expectedIssueKey)
        {
            BrowseIssue(issueUrl, expectedIssueKey);
        }

        [Test]
        [TestCaseSource(typeof(Util), nameof(Util.TestData), new object[] { "Main/Resources/issuesWithError.csv" })]
        public void BrowseIssuesWithError(string issueUrl, string errorMessage)
        {
            dashboardPage.WaitForProfileBtn();
            loginPage.NavigateTo(issueUrl);
            Assert.That(errorMessage, Is.EqualTo(issuePage.CantViewErrorDisplayed()));

        }

        [TearDown]
        public void Cleanup()
        {
            BasePage.Shutdown();
        }
    }
}
