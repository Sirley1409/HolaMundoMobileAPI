using HolaMundoAPi.Data;
using HolaMundoAPi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HolaMundoAPi.Services
{
    public class UserService : IUserService
    {

        private readonly HolaMundoDbContext _context;


        public UserService(HolaMundoDbContext context)
        {
            _context = context;
        }

        public async Task<User>? GetUserAsync(string username, string password)
        {
            if (_context.Users == null)
            {
                return null;
            }
            var user = await _context.Users.FirstOrDefaultAsync(user => user.UserName == username && user.Password == password);

            return user;
        }
    }
}
