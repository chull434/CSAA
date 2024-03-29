using System.Linq;
using CSAA.DataModels;
using CSAA.Enums;
using Microsoft.AspNet.Identity;
using Server.Models;

namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<App_Data.ServerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(App_Data.ServerDbContext context)
        {
            foreach (var user in context.Users)
            {
                context.Users.Remove(user);
            }
            foreach (var project in context.Projects)
            {
                context.Projects.Remove(project);
            }
            context.SaveChanges();

            var passwordHash = new PasswordHasher().HashPassword("password");
            var securityStamp = Guid.NewGuid().ToString();
            context.Users.AddOrUpdate(new ApplicationUser
            {
                UserName = "Test User",
                Email = "testuser@localhost.com",
                PasswordHash = passwordHash,
                product_owner = true,
                scrum_master = true,
                developer = true,
                SecurityStamp = securityStamp
            });
            context.Users.AddOrUpdate(new ApplicationUser
            {
                UserName = "Test User 2",
                Email = "testuser2@localhost.com",
                PasswordHash = passwordHash,
                product_owner = true,
                scrum_master = true,
                developer = true,
                SecurityStamp = securityStamp
            });
            context.SaveChanges();

            var Project = new Project("Project 1");
            var userId = context.Users.FirstOrDefault(u => u.Email == "testuser@localhost.com").Id;
            Project.ProjectTeam.Add(new ProjectTeamMember(userId, Project, Role.ProjectManager));
            context.Projects.AddOrUpdate(Project);
            context.SaveChanges();

            var UserStory = new UserStory("User Story One", "User Story Oen Description") { ProjectId = Project.Id, StoryPoints = 10, Priority = 1, MarketValue = 10 };
            Project.ProjectUserStories.Add(UserStory);
            context.UserStories.AddOrUpdate(UserStory);
            context.Projects.AddOrUpdate(Project);
            context.SaveChanges();

            var Project2 = new Project("Project 2");
            var userId2 = context.Users.FirstOrDefault(u => u.Email == "testuser2@localhost.com").Id;
            Project2.ProjectTeam.Add(new ProjectTeamMember(userId2, Project2, Role.ProjectManager));
            context.Projects.AddOrUpdate(Project2);
            context.SaveChanges();
        }
    }
}
