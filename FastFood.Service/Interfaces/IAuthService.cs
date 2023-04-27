namespace FastFood.Service.Interfaces;

public interface IAuthService
{
    ValueTask<string> GenerateTokenAsync(string userName,string password);
}
