using CSAA.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Server.App_Data
{
    public class SprintTeamMemberRepository : Repository, IRepository<SprintTeamMember>
    {
        public SprintTeamMemberRepository(ServerDbContext context)
        {
            this.context = context;
        }

        public List<SprintTeamMember> GetAll()
        {
            return context.SprintTeamMembers.ToList();
        }

        public SprintTeamMember GetByID(string id)
        {
            return context.SprintTeamMembers.FirstOrDefault(m => m.Id.ToString() == id);
        }

        public void Insert(SprintTeamMember member)
        {
            context.SprintTeamMembers.Add(member);
        }

        public void Delete(string id)
        {
            var member = GetByID(id);
            context.SprintTeamMembers.Remove(member);
        }
    }
}