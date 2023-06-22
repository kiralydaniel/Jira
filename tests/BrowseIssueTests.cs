using Jira.main.pageFactory;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jira.tests
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
            loginPage.NavigateTo(Util.baseURL);
            loginPage.LoggingIn(Util.username, Util.password);
        }

        public void BrowseIssue(string issueUrl, string expectedIssueKey)
        {
            dashboardPage.WaitForProfileBtn();
            loginPage.NavigateTo(issueUrl);
            Assert.That(expectedIssueKey, Is.EqualTo(issuePage.GetIssueKey()));
        }

        [Test]
        [TestCaseSource(typeof(Util), nameof(Util.TestData), new object[] { "main/resources/issues.csv" })]
        public void BrowseIssueTest(string issueUrl, string expectedIssueKey)
        {
            BrowseIssue(issueUrl, expectedIssueKey);
        }

        [TearDown]
        public void Cleanup()
        {
            BasePage.Teardown();
        }
    }
}
