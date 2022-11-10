using ProjectV2.Common.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Bll.Interfaces
{
    public interface ITokenService
    {
        ClaimsIdentity GetIdentity(LoginDto loginDto);
    }
}
