﻿using Jira.main.pageFactory;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraCsharp.tests
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
        public void validLogin()
        {
            loginPage.loggingIn(Util.username, Util.password);

        }
        [TearDown]
        public void Cleanup()
        {
            BasePage.Teardown();
        }
    }
}