namespace Server.Services
{
    public interface IEmailService
    {
        void SendEmail(string address, string subject, string body);
    }
}