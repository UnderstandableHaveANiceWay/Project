using Microsoft.EntityFrameworkCore;
using ProjectV2.Common.Exceptions;
using ProjectV2.Common.Dtos.Account;
using ProjectV2.Dal.Interfaces;
using ProjectV2.Domain;
using System.Security.Claims;
using ProjectV2.Bll.Interfaces;

namespace ProjectV2.Bll.Services
{
    public class TokenService : ITokenService
    {
        private IRepository<User> _userRepository;

        public TokenService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public ClaimsIdentity GetIdentity(LoginDto loginDto)
        {
            var user = _userRepository
                .GetIQueryableAll()
                .Include(u => u.Role)
                .FirstOrDefault(x => x.Username == loginDto.Username && x.Password == loginDto.Password);

            if (user is null) throw new AccountException("Invalid username or password.");

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
            };

            var claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
