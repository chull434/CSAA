using System;
using System.ComponentModel;
using System.Security.Claims;
using System.Threading.Tasks;
using CSAA.ServiceModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool product_owner { get; set; }
        public bool scrum_master { get; set; }
        public bool developer { get; set; }
        public string Description { get; set; }
        public string Profile { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager,
            string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public User Map()
        {
            return new User()
            {
                Id = Id,
                Name = UserName,
                Email = Email,
                Description = Description,
                Profile = Profile,
                product_owner = product_owner,
                scrum_master = scrum_master,
                developer = developer
            };

        }
    }
}   