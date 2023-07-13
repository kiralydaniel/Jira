using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Jira.Main.PageFactory
{
    public class DashboardPage : BasePage
    {
        private readonly By profileBtnLocator = By.Id("header-details-user-fullname");
        private readonly By profileLocator = By.Id("view_profile");
        private readonly By logoutBtnLocator = By.Id("log_out");
        private readonly By createBtnLocator = By.Id("create_link");
        private readonly By projectFieldLocator = By.Id("project-field");
        private readonly By issueTypeFieldLocator = By.Id("issuetype-field");
        private readonly By summaryFieldLocator = By.Id("summary");
        private readonly By createIssueBtnLocator = By.Id("create-issue-submit");
        private readonly By cancelIssueBtnLocator = By.XPath("//*[text()='Cancel']");
        private readonly By createIssueStringLocator = By.XPath("//h2[normalize-space()='Create Issue']");
        private readonly By createdIssueLinkLocator = By.CssSelector(".issue-created-key.issue-link");
        private readonly By issueSummaryErrorMsgLocator = By.XPath("//*[@id='dialog-form']/div/div[2]/div[1]/div");
        

        private IWebElement profileBtn;
        private IWebElement profile;
        private IWebElement logoutBtn;
        private IWebElement createBtn;
        private IWebElement projectField;
        private IWebElement issueTypeField;
        private IWebElement summaryField;
        private IWebElement createIssueBtn;
        private IWebElement createIssueString;
        private IWebElement createdIssueLink;
        private IWebElement cancelIssueBtn;
        private IWebElement issueSummaryErrorMsg;

        public DashboardPage() : base()
        {
        }

        public string GetSummaryErrorMsg()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(issueSummaryErrorMsgLocator));
            issueSummaryErrorMsg = driver.FindElement(issueSummaryErrorMsgLocator);
            return issueSummaryErrorMsg.Text;
        }
        
        public void ClickProfileBtn()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(profileBtnLocator));
            profileBtn = driver.FindElement(profileBtnLocator);
            profileBtn.Click();
        }

        public void ClickProfile()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(profileLocator));
            profile = driver.FindElement(profileLocator);
            profile.Click();
        }
        public void ClickLogoutBtn()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(logoutBtnLocator));
            logoutBtn = driver.FindElement(logoutBtnLocator);
            logoutBtn.Click();
        }
        public void NavigateProfilePage()
        {
            ClickProfileBtn();
            ClickProfile();
        }

        public void Logout()
        {
            ClickProfileBtn();
            ClickLogoutBtn();
        }
        public void WaitForProfileBtn()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(profileBtnLocator));
        }
        public void ClickCreatedIssueLink()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(createdIssueLinkLocator));
            createdIssueLink = driver.FindElement(createdIssueLinkLocator);
            createdIssueLink.Click();
        }

        public void ClickCreateBtn()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(createBtnLocator));
            createBtn = driver.FindElement(createBtnLocator);
            createBtn.Click();
        }

        public void ClickCreateIssueBtn()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(createIssueBtnLocator));
            createIssueBtn = driver.FindElement(createIssueBtnLocator);
            createIssueBtn.Click();
        }

        public void ClickCancelIssueBtn()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(cancelIssueBtnLocator));
            cancelIssueBtn = driver.FindElement(cancelIssueBtnLocator);
            cancelIssueBtn.Click();
        }

        public void FillProjectField(string project)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(projectFieldLocator));
            projectField = driver.FindElement(projectFieldLocator);
            projectField.Click();
            projectField.SendKeys(project);
            createIssueString = driver.FindElement(createIssueStringLocator);
            createIssueString.Click();
        }

        public void FillTypeField(string issueType)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(issueTypeFieldLocator));
            issueTypeField = driver.FindElement(issueTypeFieldLocator);
            issueTypeField.Click();
            issueTypeField.SendKeys(issueType);
            createIssueString = driver.FindElement(createIssueStringLocator);
            createIssueString.Click();
        }

        public void FillSummaryField(string summaryData)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(summaryFieldLocator));
            summaryField = driver.FindElement(summaryFieldLocator);
            summaryField.SendKeys(summaryData);
        }
    }
}
