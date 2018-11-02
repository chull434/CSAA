using CSAA.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Server.App_Data
{
    public class ProjectTeamMemberRepository : Repository, IRepository<ProjectTeamMember>
    {
        public ProjectTeamMemberRepository(ServerDbContext context)
        {
            this.context = context;
        }

        public List<ProjectTeamMember> GetAll()
        {
            return context.ProjectTeamMembers.ToList();
        }

        public ProjectTeamMember GetByID(string id)
        {
            return context.ProjectTeamMembers.FirstOrDefault(m => m.Id.ToString() == id);
        }

        public void Insert(ProjectTeamMember member)
        {
            context.ProjectTeamMembers.Add(member);
        }

        public void Delete(string id)
        {
            var member = GetByID(id);
            context.ProjectTeamMembers.Remove(member);
        }
    }
}