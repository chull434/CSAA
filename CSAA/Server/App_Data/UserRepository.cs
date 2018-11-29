using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.App_Data
{
    public class UserRepository : Repository, IRepository<ApplicationUser>
    {
        public UserRepository(ServerDbContext context)
        {
            this.context = context;
        }

        public List<ApplicationUser> GetAll()
        {
            return context.Users.ToList();
        }

        public ApplicationUser GetByID(string id)
        {
            return context.Users.FirstOrDefault(u => u.Id.ToString() == id);
        }

        public void Insert(ApplicationUser user)
        {
            context.Users.Add(user);
        }

        public void Delete(string id)
        {
            var user = GetByID(id);
            context.Users.Remove(user);
        }
    }
}