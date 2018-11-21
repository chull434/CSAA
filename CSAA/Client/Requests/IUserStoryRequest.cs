using System.Collections.Generic;
using CSAA.ServiceModels;

namespace Client.Requests
{
    interface IUserStoryRequest
    {
        List<UserStory> GetUserStories();
        UserStory GetUserStoryById(string userStoryId);
        string CreateUserStory(UserStory userStory);
    }
}
