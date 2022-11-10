using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectV2.Common.Exceptions
{
    public class NotExistInDbException : ApiException
    {
        private static readonly string _warningMessage = "not exist";
        private static readonly HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest;
        public NotExistInDbException() : base(httpStatusCode)
        {
        }
        public NotExistInDbException(string? additionalInformation) : base(httpStatusCode, $"{_warningMessage} {additionalInformation}")
        {
        }
        public NotExistInDbException(string? additionalInformation, Exception innerException)
            : base(httpStatusCode, $"{_warningMessage} {additionalInformation}", innerException)
        {
        }
    }
}
