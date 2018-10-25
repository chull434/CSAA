using System;
using System.Configuration;
using System.IO;
using System.Linq;
using Client.Requests;
using CSAA.Models;
using FunctionalTests.App_Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using FunctionalTests.Utils;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace FunctionalTests.Steps
{
    [Binding]
    public class AccountFeatureSteps
    {
        public static FunctionalDbContext context;
        public static Application app;
        public static Window window;

        [BeforeScenario]
        public void BeforeScenario()
        {
            var dataDirectory = ConfigurationManager.AppSettings["DataDirectory"];
            var absoluteDataDirectory = Path.GetFullPath(dataDirectory);
            AppDomain.CurrentDomain.SetData("DataDirectory", absoluteDataDirectory);
            context = new FunctionalDbContext();

            var BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var exe = Path.GetFullPath(BaseDirectory + "..\\..\\..\\..\\Client\\bin\\Debug\\Client.exe");
            app = Application.Launch(exe);        
        }

        [AfterScenario]
        public void AfterScenario()
        {
            app.Close();
        }

        [When(@"I click ""(.*)""")]
        public void WhenIClick(string value)
        {
            var btn = window.Get<Button>("btn_" + value);
            btn.Click();
        }

        [When(@"I enter the following:")]
        public void WhenIEnterTheFollowing(Table table)
        {
            var dictionary = table.ToDictionary();

            foreach (var key in dictionary.Keys)
            {
                var txt = window.Get<TextBox>("txt_" + key);
                txt.Text = dictionary[key];
            }
        }

        [When(@"I enter the following passwords:")]
        public void WhenIEnterTheFollowingPasswords(Table table)
        {
            var dictionary = table.ToDictionary();

            foreach (var key in dictionary.Keys)
            {
                var txt = window.Get<TextBox>("pwb_" + key);
                txt.Text = dictionary[key];
            }
        }

        [When(@"I check the following:")]
        public void WhenICheckTheFollowing(Table table)
        {
            var dictionary = table.ToDictionary();

            foreach (var key in dictionary.Keys)
            {
                var chk = window.Get<CheckBox>("chk_" + key);
                chk.Checked = dictionary[key].ToBoolean();
            }
        }

        [Then(@"I am on the ""(.*)"" page")]
        public void ThenIAmOn(string value)
        {
            window = app.GetWindow(value, InitializeOption.NoCache);
        }

        [Then(@"the a user account is created with the following details:")]
        public void ThenTheAUserAccountIsCreatedWithTheFollowingDetails(Table table)
        {
            var dictionary = table.ToDictionary();
            var username = dictionary["Name"];
            var user = context.Users.FirstOrDefault(u => u.UserName == username);
            Assert.IsNotNull(user);
        }

        [Then(@"the no user accounts are created")]
        public void ThenTheNoUserAccountsAreCreated()
        {
            var accounts = context.Users.Any();
            Assert.IsFalse(accounts);
        }

        [Then(@"the following errors appear:")]
        public void ThenTheFollowingErrorsAppear(Table table)
        {
            var dictionary = table.ToDictionary();

            foreach (var key in dictionary.Keys)
            {
                var lbl = window.Get<Label>("lbl_" + key);
                Assert.IsTrue(lbl.Text == dictionary[key]);
                Assert.IsTrue(lbl.Visible);
            }
        }
    }
}
