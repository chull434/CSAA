using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSAA.DataModels;

namespace Server.App_Data
{
    public class TaskRepository : Repository, IRepository<Task>
    {
        public TaskRepository(ServerDbContext context)
        {
            this.context = context;
        }

        public List<Task> GetAll()
        {
            return context.Tasks.ToList();
        }

        public Task GetByID(string id)
        {
            return context.Tasks.FirstOrDefault(p => p.Id.ToString() == id);
        }

        public void Insert(Task task)
        {
            context.Tasks.Add(task);
        }

        public void Delete(string id)
        {
            var task = GetByID(id);
            context.Tasks.Remove(task);
        }
    }
}