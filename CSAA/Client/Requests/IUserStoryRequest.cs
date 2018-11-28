using System.Collections.Generic;
using CSAA.ServiceModels;

namespace Client.Requests
{
    public interface IUserStoryRequest
    {
        List<UserStory> GetUserStories();
        UserStory GetUserStoryById(string userStoryId);
        string CreateUserStory(UserStory userStory);
        bool UpdateUserStory(string userStoryId, UserStory userStory);
        bool DeleteUserStory(string userStoryId);
    }
}
