using System;
using System.Collections.Generic;
using System.Linq;
using CSAA.Models;

namespace Server.App_Data
{
    public class ProjectRepository : Repository, IRepository<Project>
    {
        public ProjectRepository(ServerDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Project> GetAll()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}