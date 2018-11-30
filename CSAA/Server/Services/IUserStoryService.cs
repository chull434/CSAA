using CSAA.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface IUserStoryService
    {
        List<UserStory> GetAllUserStories();
        UserStory GetUserStory(string UserStoryId, string userId);
        string CreateUserStory(UserStory userStory);
        void UpdateUserStory(string userStoryId, UserStory userStory);
        void DeleteUserStory(string userStoryId);
        void SetApplicationUserManager(IApplicationUserManager applicationUserManager);
    }
}
