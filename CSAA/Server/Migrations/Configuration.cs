using System.Linq;
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
            context.SaveChanges();
        }
    }
}
