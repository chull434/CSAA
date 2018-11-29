using CSAA.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Server.App_Data
{
    public class SprintRepository : Repository, IRepository<Sprint>
    {
        public SprintRepository(ServerDbContext context)
        {
            this.context = context;
        }

        public List<Sprint> GetAll()
        {
            return context.Sprints.ToList();
        }

        public Sprint GetByID(string id)
        {
            return context.Sprints.FirstOrDefault(p => p.Id.ToString() == id);
        }

        public void Insert(Sprint sprint)
        {
            context.Sprints.Add(sprint);
        }

        public void Delete(string id)
        {
            var sprint = GetByID(id);
            context.Sprints.Remove(sprint);
        }
    }
}