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
            var testUser = context.Users.FirstOrDefault(u => u.UserName == "Test User");
            if (testUser == null)
            {
                var passwordHash = new PasswordHasher().HashPassword("password");
                var securityStamp = Guid.NewGuid().ToString();
                var user = new ApplicationUser
                {
                    UserName = "Test User",
                    Email = "testuser@localhost.com",
                    PasswordHash = passwordHash,
                    product_owner = true,
                    scrum_master = true,
                    developer = true,
                    SecurityStamp = securityStamp
                };
                context.Users.AddOrUpdate(user);
            }
        }
    }
}
