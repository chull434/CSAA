using Server.Models;

namespace Server
{
    public interface IApplicationUserManager
    {
        ApplicationUser FindUserByEmail(string email);
        ApplicationUser FindUserById(string id);
        string GetUserNameById(string userId);
        string GetUserEmailById(string userId);
        void UpdateUser(ApplicationUser user);
    }
}