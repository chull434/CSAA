using System;
using System.Configuration;
using System.IO;
using System.Linq;
using FunctionalTests.App_Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using FunctionalTests.Utils;
using Server.Models;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace FunctionalTests.Steps
{
    [Binding]
    public class DatabaseSteps
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

        #region Given Steps

        [Given(@"the following user account exists:")]
        public void GivenTheFollowingUserAccountExists(Table table)
        {
            var dictionary = table.ToDictionary();
            var username = dictionary["Name"];
            var email = dictionary["Email"];
            var password = dictionary["Password"];
            var productOwner = dictionary["ProductOwner"].ToBoolean();
            var scumMaster = dictionary["ScumMaster"].ToBoolean();
            var developer = dictionary["Developer"].ToBoolean();
            var user = new ApplicationUser
            {
                UserName = username,
                Email = email,
                PasswordHash = password,
                product_owner = productOwner,
                scrum_master = scumMaster,
                developer = developer 
            };
            context.Users.Add(user);
            context.SaveChanges();
        }

        #endregion

        #region Then Steps

        [Then(@"the a user account is created with the following details:")]
        public void ThenTheAUserAccountIsCreatedWithTheFollowingDetails(Table table)
        {
            var dictionary = table.ToDictionary();
            var username = dictionary["Name"];
            var email = dictionary["Email"];
            var password = dictionary["Password"];
            var productOwner = dictionary["ProductOwner"].ToBoolean();
            var scumMaster = dictionary["ScumMaster"].ToBoolean();
            var developer = dictionary["Developer"].ToBoolean();
            var user = context.Users.FirstOrDefault(u => u.UserName == username && 
                                                         u.Email == email && 
                                                         u.product_owner == productOwner && 
                                                         u.scrum_master == scumMaster && 
                                                         u.developer == developer);
            Assert.IsNotNull(user);
        }

        [Then(@"the no user accounts are created")]
        public void ThenTheNoUserAccountsAreCreated()
        {
            var accounts = context.Users.Any();
            Assert.IsFalse(accounts);
        }

        #endregion
    }
}
