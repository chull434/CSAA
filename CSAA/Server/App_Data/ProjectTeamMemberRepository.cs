using System;
using System.Collections.Generic;
using System.Linq;
using CSAA.Models;

namespace Server.App_Data
{
    public class ProjectTeamMemberRepository : IRepository<ProjectTeamMember>
    {
        ServerDbContext context;

        public ProjectTeamMemberRepository(ServerDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<ProjectTeamMember> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProjectTeamMember GetByID(string id)
        {
            throw new NotImplementedException();
        }

        public string GetUserIdFromEmail(string email)
        {
            var user = context.Users.SingleOrDefault(u => u.Email == email);
            if (user != null)
                return user.Id;

            return null;
        }

        public void Insert(ProjectTeamMember member)
        {
            context.ProjectTeamMembers.Add(member);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}