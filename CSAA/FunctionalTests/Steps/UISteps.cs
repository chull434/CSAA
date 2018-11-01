using System;
using System.Configuration;
using System.IO;
using System.Linq;
using FunctionalTests.App_Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using FunctionalTests.Utils;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.UIItems.Finders;

namespace FunctionalTests.Steps
{
    [Binding]
    public class UISteps
    {
        public static Application app;
        public static Window window;

        [BeforeScenario]
        public void BeforeScenario()
        {
            var BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var exe = Path.GetFullPath(BaseDirectory + "..\\..\\..\\..\\Client\\bin\\Debug\\Client.exe");
            app = Application.Launch(exe);        
        }

        [AfterScenario]
        public void AfterScenario()
        {
            app.Close();
        }

        #region When Steps

        [When(@"I click ""(.*)""")]
        public void WhenIClick(string value)
        {
            var btn = window.Get<Button>("btn_" + value);
            btn.Click();
        }

        [When(@"I click ""(.*)"" in the menu")]
        public void WhenIClickMenu(string value)
        {
            var menuBar = window.MenuBar;
            var btn = menuBar.MenuItemBy(SearchCriteria.ByText(value));
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

        #endregion

        #region Then Steps

        [Then(@"I am on the ""(.*)"" page")]
        public void ThenIAmOn(string value)
        {
            window = app.GetWindows().FirstOrDefault(w => w.Name == value && !w.IsClosed);
            Assert.IsNotNull(window);
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

        #endregion
    }
}
