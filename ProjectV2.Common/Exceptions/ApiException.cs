using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Common.Exceptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode Code { get; }

        public ApiException(HttpStatusCode code) : base()
        {
            Code = code;
        }
        public ApiException(HttpStatusCode code, string? message) : base(message)
        {
            Code = code;
        }
        public ApiException(HttpStatusCode code, string? message, Exception innerException) : base(message, innerException)
        {
            Code = code;
        }
    }
}
