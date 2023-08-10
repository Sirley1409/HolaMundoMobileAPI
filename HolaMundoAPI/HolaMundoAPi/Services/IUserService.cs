using HolaMundoAPi.Data.Models;

namespace HolaMundoAPi.Services
{
    public interface IUserService
    {
        Task<User>? GetUserAsync(string username, string password);
    }
}
