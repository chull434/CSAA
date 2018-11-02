using CSAA.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Server.App_Data
{
    public class ProjectRepository : Repository, IRepository<Project>
    {
        public ProjectRepository(ServerDbContext context)
        {
            this.context = context;
        }

        public List<Project> GetAll()
        {
            return context.Projects.ToList();
        }

        public Project GetByID(string id)
        {
            return context.Projects.FirstOrDefault(p => p.Id.ToString() == id);
        }

        public void Insert(Project project)
        {
            context.Projects.Add(project);
        }

        public void Delete(string id)
        {
            var project = GetByID(id);
            context.Projects.Remove(project);
        }
    }
}