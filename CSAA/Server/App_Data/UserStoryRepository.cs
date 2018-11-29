using CSAA.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.App_Data
{
    public class UserStoryRepository : Repository, IRepository<UserStory>
    {
        public UserStoryRepository(ServerDbContext context)
        {
            this.context = context;
        }

        public List<UserStory> GetAll()
        {
            return context.UserStories.ToList();
        }

        public UserStory GetByID(string id)
        {
            return context.UserStories.FirstOrDefault(p => p.Id.ToString() == id);
        }

        public void Insert(UserStory userStory)
        {
            context.UserStories.Add(userStory);
        }

        public void Delete(string id)
        {
            var userStory = GetByID(id);
            context.UserStories.Remove(userStory);
        }
    }
}