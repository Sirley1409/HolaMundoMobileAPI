using HolaMundoAPi.Data.Models;

namespace HolaMundoAPi.Services
{
        public interface IAccountService
        {
            string GenerateJwtToken(User user);
        }

}

