using NUnit.Framework;
using Jira.Main.PageFactory;


namespace Jira.Tests
{
    [TestFixture]
    public class EditIssueTest
    {
        private static LoginPage loginPage;
        private static IssuePage issuePage;
        private static DashboardPage dashboardPage;
        private const string summaryData = "TestIssue1";
        private const string editData = "TestIssue2";
        private const string emptyError = "You must specify a summary of the issue.";

        [SetUp]
        public void Init()
        {
            dashboardPage = new DashboardPage();
            loginPage = new LoginPage();
            issuePage = new IssuePage();
            loginPage.NavigateTo(Util.BaseURL);
            loginPage.LoggingIn(Util.Username, Util.Password);
        }

        private void editIssueProjects(string url, string expectedResult)
        {
            dashboardPage.WaitForProfileBtn();
            loginPage.NavigateTo(url);
            Assert.That(issuePage.GetIssueKey(), Is.EqualTo(expectedResult));
        }

        private void editIssue(string url, string expectedResult, string newValue)
        {
            dashboardPage.WaitForProfileBtn();
            loginPage.NavigateTo(url);
            Assert.That(issuePage.GetIssueKey(), Is.EqualTo(expectedResult));
            issuePage.ClickOnEditIssueBtn();
            issuePage.EditSummary(newValue);
        }

        [Test]
        [TestCaseSource(typeof(Util), nameof(Util.TestData), new object[] { "Main/Resources/issues.csv" })]
        public void EditIssueProjectsTest(string url, string expectedResult)
        {
            editIssueProjects(url, expectedResult);     
        }

        [Test]
        [TestCaseSource(typeof(Util), nameof(Util.TestData), new object[] { "Main/Resources/editIssue.csv" })]
        public void SuccessfullyEditIssue(string url, string expectedResult)
        {
            editIssue(url, expectedResult, editData);
            issuePage.ClickOnUpdateBtn();
            issuePage.WaitForUpdate();
            Assert.That(issuePage.GetIssueKey(), Is.EqualTo(expectedResult));
            Assert.That(issuePage.GetSummary(), Is.EqualTo(editData));
            issuePage.ClickOnEditIssueBtn();
            issuePage.EditSummary(summaryData);
            issuePage.ClickOnUpdateBtn();
            issuePage.WaitForUpdate();
            Assert.That(issuePage.GetIssueKey(), Is.EqualTo(expectedResult));
            Assert.That(issuePage.GetSummary(), Is.EqualTo(summaryData));
        }

        [Test]
        [TestCaseSource(typeof(Util), nameof(Util.TestData), new object[] { "Main/Resources/editIssue.csv" })]
        public void CancelEditIssue(string url, string expectedResult)
        {
            editIssue(url, expectedResult, editData);
            issuePage.ClickOnCancelButtonAndAcceptAlert();
            Assert.That(issuePage.GetIssueKey(), Is.EqualTo(expectedResult));
            Assert.That(issuePage.GetSummary(), Is.EqualTo(summaryData));
        }

        [Test]
        [TestCaseSource(typeof(Util), nameof(Util.TestData), new object[] { "Main/Resources/editIssue.csv" })]
        public void EmptyRequiredField(string url, string expectedResult)
        {
            editIssue(url, expectedResult, "");
            issuePage.ClickOnUpdateBtn();
            Assert.That(issuePage.ErrorDisplayed(), Is.EqualTo(emptyError));
            issuePage.ClickOnCancelButtonAndAcceptAlert();
        }

        [TearDown]
        public void Cleanup()
        {
            BasePage.Shutdown();
        }
    }
}
