using CSAA.Models;

namespace Client.Requests
{
    public interface IAccountRequest
    {
        bool Register(User user);
        bool Login(string text, string password);
        bool Logout();
    }
}
