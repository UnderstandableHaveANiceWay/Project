using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Common.Exceptions
{
    public class AccountException : ApiException
    {
        private static readonly HttpStatusCode httpStatusCode = HttpStatusCode.Forbidden;

        public AccountException() : base(httpStatusCode)
        {
        }
        public AccountException(string? message) : base(httpStatusCode, message)
        {
        }
        public AccountException(string? message, Exception innerException)
            : base(httpStatusCode, message, innerException)
        {
        }
    }
}
