using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;


namespace Jira.Main.PageFactory
{
    public class IssuePage : BasePage
    {
        private readonly By issueKeyLocator = By.Id("key-val");
        private readonly By moreBtnLocator = By.Id("opsbar-operations_more");
        private readonly By deleteBtnLocator = By.Id("delete-issue");
        private readonly By editIssueBtnLocator = By.Id("edit-issue");
        private readonly By editIssueSummaryLocator = By.Id("summary");
        private readonly By summaryLocator = By.Id("summary-val");
        private readonly By typeLocator = By.Id("type-val");
        private readonly By deleteIssuePopUpLocator = By.XPath("//div[@class='aui-message closeable aui-message-success aui-will-close']");
        private readonly By popUpDeleteBtnLocator = By.XPath("//*[@id='delete-issue-submit']");
        private readonly By issueListLocator = By.XPath("//*[@id='main']/div/div[2]/div/div/div/div/div/div[1]/div[1]/div/div[1]/div[2]/div/ol");
        private readonly By editBtnLocator = By.Id("edit-issue-submit");
        private readonly By cancelBtnLocator = By.XPath("//button[normalize-space()='Cancel']");
        private readonly By errorFieldLocator = By.XPath("//div[@class='error']");
        private readonly By errorLocator = By.CssSelector("h1");
        private readonly By updateConfirmLocator = By.Id("aui-flag-container");

        private IWebElement issueKey;
        private IWebElement moreBtn;
        private IWebElement deleteBtn;
        private IWebElement editIssueBtn;
        private IWebElement editIssueSummary;
        private IWebElement summary;
        private IWebElement type;
        private IWebElement deleteIssuePopUp;
        private IWebElement popUpDeleteBtn;
        private IWebElement issueList;
        private IWebElement editBtn;
        private IWebElement cancelBtn;
        private IWebElement errorField;
        private IWebElement error;
        private IWebElement updateConfirm;

        public IssuePage() : base()
        {
        }

        public string GetIssueKey()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(issueKeyLocator));
            issueKey = driver.FindElement(issueKeyLocator);
            return issueKey.Text;
        }

        public string GetSummary()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(summaryLocator));
            summary = driver.FindElement(summaryLocator);
            return summary.Text;
        }

        public string GetTheType()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(typeLocator));
            type = driver.FindElement(typeLocator);
            return type.Text;
        }

        public void ClickMoreBtn()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(moreBtnLocator));
            moreBtn = driver.FindElement(moreBtnLocator);
            moreBtn.Click();
        }

        public void ClickDeleteBtn()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(deleteBtnLocator));
            deleteBtn = driver.FindElement(deleteBtnLocator);
            deleteBtn.Click();
        }

        public void ClickPopUpDeleteBtn()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(popUpDeleteBtnLocator));
            popUpDeleteBtn = driver.FindElement(popUpDeleteBtnLocator);
            popUpDeleteBtn.Click();
        }

        public bool DeletedIssueValidate()
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(deleteIssuePopUpLocator));
            deleteIssuePopUp = driver.FindElement(deleteIssuePopUpLocator);
            return deleteIssuePopUp.Displayed;
        }

        public void DeleteIssue()
        {
            ClickMoreBtn();
            ClickDeleteBtn();
            ClickPopUpDeleteBtn();
        }
        public void ClickOnEditIssueBtn()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(editIssueBtnLocator));
            editIssueBtn = driver.FindElement(editIssueBtnLocator);
            editIssueBtn.Click();
        }

        public void EditBtnVisible()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(editIssueBtnLocator));
        }

        public void EditSummary(string text)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(editIssueSummaryLocator));
            editIssueSummary = driver.FindElement(editIssueSummaryLocator);
            editIssueSummary.Clear();
            editIssueSummary.SendKeys(text);
        }

        public void ClickOnUpdateBtn()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(editBtnLocator));
            editBtn = driver.FindElement(editBtnLocator);
            editBtn.Click();
        }

        public void WaitForUpdate()
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(updateConfirmLocator));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(updateConfirmLocator));
        }

        public void ClickOnCancelButtonAndAcceptAlert()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(cancelBtnLocator));
            cancelBtn = driver.FindElement(cancelBtnLocator);
            cancelBtn.Click();
            driver.SwitchTo().Alert().Accept();
        }

        public string ErrorDisplayed()
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(errorFieldLocator));
            errorField = driver.FindElement(errorFieldLocator);
            return errorField.Text;
        }

        public string CantViewErrorDisplayed()
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(errorLocator));
            error = driver.FindElement(errorLocator);
            return error.Text;
        }

    }
}
