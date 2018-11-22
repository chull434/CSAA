using CSAA.ServiceModels;

namespace Client.Requests
{
    public interface IAccountRequest
    {
        string Register(User user);
        string Login(string text, string password);
        string Logout();
        string Save();
        User GetUser();
    }
}
