using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Common.Dtos.Account
{
    public class TokenResponseDto
    {
        public string AccessToken { get; set; }
        public int Expiration { get; set; }
    }
}
