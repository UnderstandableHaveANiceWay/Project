using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ProjectV2.API.TokenOptions
{
    public class AuthOptions
    {
        public const string ISSUER = "AuthServer";

        public const string AUDIENCE = "AuthClient";

        const string KEY = "sifratorAuthorAmdarisHigherMe!123";

        public const int LIFETIME = 10;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
