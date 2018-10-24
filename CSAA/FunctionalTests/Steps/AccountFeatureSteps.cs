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
using Microsoft.AspNet.Identity;
using Server.Models;

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

        #region Given Steps

        [Given(@"a user exists:")]
        public void GivenAUserExists(Table table)
        {
            var dictionary = table.ToDictionary();
            var passwordHash = new PasswordHasher().HashPassword(dictionary["Password"]);
            var user = new ApplicationUser
            {
                UserName = dictionary["Name"],
                Email = dictionary["Email"],
                PasswordHash = passwordHash,
                product_owner = dictionary["product_owner"].ToBoolean(),
                scrum_master = dictionary["scrum_master"].ToBoolean(),
                developer = dictionary["developer"].ToBoolean()
            };
            context.Users.Add(user);
            context.SaveChanges();
        }

        #endregion

        #region When Steps

        [When(@"I register with the following details:")]
        public void WhenIRegisterWithTheFollowingDetails(Table table)
        {
            var dictionary = table.ToDictionary();
            var accountRequest = new AccountRequest();
            var user = new User
            {
                Name = dictionary["Name"],
                Email = dictionary["Email"],
                Password = dictionary["Password"],
                product_owner = dictionary["product_owner"].ToBoolean(),
                scrum_master = dictionary["scrum_master"].ToBoolean(),
                developer = dictionary["developer"].ToBoolean()
            };
            accountRequest.Register(user);
        }

        [When(@"I login with the following details:")]
        public void WhenILoginWithTheFollowingDetails(Table table)
        {
            var dictionary = table.ToDictionary();
            var accountRequest = new AccountRequest();
            accountRequest.Login(dictionary["Email"], dictionary["Password"]);
        }

        #endregion

        #region Then Steps

        [Then(@"the a user account is created with the following details:")]
        public void ThenTheAUserAccountIsCreatedWithTheFollowingDetails(Table table)
        {
            var dictionary = table.ToDictionary();
            var username = dictionary["Name"];
            var email = dictionary["Email"];
            var product_owner = dictionary["product_owner"].ToBoolean();
            var scrum_master = dictionary["scrum_master"].ToBoolean();
            var developer = dictionary["developer"].ToBoolean();
            var user = context.Users.FirstOrDefault(u => u.UserName == username &&
                                                         u.Email == email && 
                                                         u.product_owner == product_owner &&
                                                         u.scrum_master == scrum_master &&
                                                         u.developer == developer);
            Assert.IsNotNull(user);
        }

        [Then(@"the user is logged in:")]
        public void ThenTheUserIsLoggedIn(Table table)
        {
            var dictionary = table.ToDictionary();
            var email = dictionary["Email"];
            var user = context.Users.FirstOrDefault(u => u.Email == email);
            Assert.IsNotNull(user);
            Assert.IsTrue(user.Logins.Count == 1);
        }

        #endregion

    }
}
