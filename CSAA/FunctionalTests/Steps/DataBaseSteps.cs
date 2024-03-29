﻿using System;
using System.Configuration;
using System.IO;
using System.Linq;
using FunctionalTests.App_Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using FunctionalTests.Utils;
using Microsoft.AspNet.Identity;
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
            var scrumMaster = dictionary["ScrumMaster"].ToBoolean();
            var developer = dictionary["Developer"].ToBoolean();
            var passwordHash = new PasswordHasher().HashPassword(password);
            var securityStamp = Guid.NewGuid().ToString();
            var user = new ApplicationUser
            {
                UserName = username,
                Email = email,
                PasswordHash = passwordHash,
                product_owner = productOwner,
                scrum_master = scrumMaster,
                developer = developer,
                SecurityStamp = securityStamp
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
            var scrumMaster = dictionary["ScrumMaster"].ToBoolean();
            var developer = dictionary["Developer"].ToBoolean();
            var user = context.Users.FirstOrDefault(u => u.UserName == username && 
                                                         u.Email == email && 
                                                         u.product_owner == productOwner && 
                                                         u.scrum_master == scrumMaster && 
                                                         u.developer == developer);
            Assert.IsNotNull(user);
        }

        [Then(@"the no user accounts are created")]
        public void ThenTheNoUserAccountsAreCreated()
        {
            var accounts = context.Users.Any();
            Assert.IsFalse(accounts);
        }

        [Then(@"a project called ""(.*)"" exists")]
        public void ThenAProjectExists(string projectName)
        {
            var project = context.Projects.FirstOrDefault(p => p.Title == projectName);
            Assert.IsNotNull(project);
        }

        [Then(@"""(.*)"" is a team member of a project called ""(.*)""")]
        public void ThenAProjectExists(string userEmail, string projectName)
        {
            var project = context.Projects.FirstOrDefault(p => p.Title == projectName);
            Assert.IsNotNull(project);
            var user = context.Users.FirstOrDefault(u => u.Email == userEmail);
            var member = project.ProjectTeam.FirstOrDefault(m => m.UserId == user.Id);
            Assert.IsNotNull(member);
        }

        #endregion
    }
}
