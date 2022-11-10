using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectV2.API.TokenOptions;
using System.IdentityModel.Tokens.Jwt;
using ProjectV2.Bll.Interfaces;
using ProjectV2.Common.Dtos.Account;

namespace ProjectV2.API.Controllers
{
    [Route("api")]
    public class AccountController : AppBaseController
    {
        private ITokenService _tokenService;
        private IUserService _userService;

        public AccountController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpPost("token")]
        public IActionResult Token([FromBody] LoginDto loginDto)
        {
            var identity = _tokenService.GetIdentity(loginDto);

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new TokenResponseDto
            {
                AccessToken = encodedJwt,
                Expiration = AuthOptions.LIFETIME * 60 * 1000
            };
            return Ok(response);
        }

        [HttpPost("checkavailableusername")]
        public IActionResult CheckAvailableUsername([FromBody] string username)
        {
            return Ok(!_userService.UserExistByUsername(username));
        }
    }
}
