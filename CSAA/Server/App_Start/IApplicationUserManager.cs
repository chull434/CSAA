using Server.Models;

namespace Server
{
    public interface IApplicationUserManager
    {
        ApplicationUser FindUserByEmail(string email);
    }
}