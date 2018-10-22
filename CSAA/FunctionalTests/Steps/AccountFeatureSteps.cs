using System;
using System.Configuration;
using System.IO;
using System.Linq;
using Client.Requests;
using CSAA.Models;
using FunctionalTests.App_Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.App_Data;
using TechTalk.SpecFlow;

namespace FunctionalTests.Steps
{
    [Binding]
    public class AccountFeatureSteps
    {
        public static FunctionalDbContext context;

        [BeforeScenario]
        public void BeforeScenario()
        {
            var dataDirectory = ConfigurationManager.AppSettings["DataDirectory"];
            var absoluteDataDirectory = Path.GetFullPath(dataDirectory);
            AppDomain.CurrentDomain.SetData("DataDirectory", absoluteDataDirectory);
            context = new FunctionalDbContext();
        }

        [When(@"I register with the following details:")]
        public void WhenIRegisterWithTheFollowingDetails(Table table)
        {
            var AccountRequest = new AccountRequest();
            var user = new User // UI Part
            {
                Name = "Test User",
                Email = "testuser@localhost",
                Password = "password",
                product_owner = true,
                scrum_master = true,
                developer = true
            };
            AccountRequest.Register(user);
        }
        
        [Then(@"the a user account is created with the following details:")]
        public void ThenTheAUserAccountIsCreatedWithTheFollowingDetails(Table table)
        {
            var user = context.Users.FirstOrDefault(u => u.UserName == "Test User");
            Assert.IsNotNull(user);
        }
    }
}
