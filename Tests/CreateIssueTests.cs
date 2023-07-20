using Jira.Main.PageFactory;
using NUnit.Framework;


namespace Jira.Tests
{
    [TestFixture]
    public class CreateissueTests
    {
        private LoginPage loginPage;
        private IssuePage issuePage;
        private DashboardPage dashboardPage;
        private readonly string createTestString = "New Issue1";
        private readonly string summaryErrorMsg = "You must specify a summary of the issue.";

        [SetUp]
        public void Init()
        {
            loginPage = new LoginPage();
            issuePage = new IssuePage();
            dashboardPage = new DashboardPage();
            loginPage.NavigateTo(Util.BaseURL);
            loginPage.LoggingIn(Util.Username, Util.Password);
        }

        private void CancelCreation(string project, string type, string summary)
        {
            dashboardPage.ClickCreateBtn();
            dashboardPage.FillProjectField(project);
            dashboardPage.FillTypeField(type);
            dashboardPage.FillSummaryField(summary);
            dashboardPage.ClickCancelIssueBtn();
        }

        private void SuccessfulCreateIssue(string project, string type, string summary)
        {
            dashboardPage.ClickCreateBtn();
            dashboardPage.FillProjectField(project);
            dashboardPage.FillTypeField(type);
            dashboardPage.FillSummaryField(summary);
            dashboardPage.ClickCreateIssueBtn();
            dashboardPage.ClickCreatedIssueLink();
            Assert.Multiple(() =>
            {
                Assert.That(type, Is.EqualTo(issuePage.GetTheType()));
                Assert.That(summary, Is.EqualTo(issuePage.GetSummary()));
            });
            issuePage.DeleteIssue();
            Assert.That(issuePage.DeletedIssueValidate(), Is.True);
        }

        [Test]
        public void EmptyFields()
        {
            dashboardPage.ClickCreateBtn();
            dashboardPage.ClickCreateIssueBtn();
            Assert.That(summaryErrorMsg, Is.EqualTo(dashboardPage.GetSummaryErrorMsg()));
        }

        [Test]
        [TestCaseSource(typeof(Util), nameof(Util.TestData), new object[] { "Main/Resources/createIssue.csv" })]
        public void CreateIssue(string project, string type)
        {
            SuccessfulCreateIssue(project, type, createTestString);
        }

        [Test]
        [TestCaseSource(typeof(Util), nameof(Util.TestData), new object[] { "Main/Resources/cancelIssue.csv" })]
        public void CancelIssueCreation(string project, string type)
        {
            CancelCreation(project, type, createTestString);
        }

        [TearDown]
        public void Cleanup()
        {
            BasePage.Shutdown();
        }
    }
}
