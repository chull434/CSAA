using System.Collections.Generic;
using CSAA.ServiceModels;

namespace Client.Requests
{
    public interface IUserRequest
    {
        List<User> GetUsers();
        User GetUser(string userId);
        string CreateUser(User user);
        bool UpdateUser(string userId, User user);
        bool DeleteUser(string userId);
    }
}
