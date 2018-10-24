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
using FunctionalTests.Utils;

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
            var dictionary = table.ToDictionary();
            var AccountRequest = new AccountRequest();
            var user = new User
            {
                Name = dictionary["Name"],
                Email = dictionary["Email"],
                Password = dictionary["Password"],
                product_owner = dictionary["product_owner"].ToBoolean(),
                scrum_master = dictionary["scrum_master"].ToBoolean(),
                developer = dictionary["developer"].ToBoolean()
            };
            AccountRequest.Register(user);
        }
        
        [Then(@"the a user account is created with the following details:")]
        public void ThenTheAUserAccountIsCreatedWithTheFollowingDetails(Table table)
        {
            var dictionary = table.ToDictionary();
            var username = dictionary["Name"];
            var user = context.Users.FirstOrDefault(u => u.UserName == username);
            Assert.IsNotNull(user);
        }
    }
}
