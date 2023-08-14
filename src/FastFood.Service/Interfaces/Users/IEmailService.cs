namespace FastFood.Service.Interfaces.Users
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string message);
    }
}
