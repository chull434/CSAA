using CSAA.ServiceModels;
using System.Collections.Generic;

namespace Server.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUser(string userId);
        string CreateUser(User user);
        void UpdateUser(string userId, User user);
        void DeleteUser(string userId);
        void SetApplicationUserManager(IApplicationUserManager applicationUserManager);
    }
}
