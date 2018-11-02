using Server.Models;

namespace Server
{
    public interface IApplicationUserManager
    {
        ApplicationUser FindUserByEmail(string email);
        string GetUserNameById(string userId);
        string GetUserEmailById(string userId);
    }
}