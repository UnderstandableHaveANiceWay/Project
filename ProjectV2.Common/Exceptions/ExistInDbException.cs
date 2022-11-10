using System.Net;

namespace ProjectV2.Common.Exceptions
{
    public class ExistInDbException : ApiException
    {
        private static readonly string _warningMessage = "already exist";
        private static readonly HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest;
        public ExistInDbException() : base(httpStatusCode)
        {
        }
        public ExistInDbException(string? additionalInformation) : base(httpStatusCode, $"{_warningMessage} {additionalInformation}")
        {
        }
        public ExistInDbException(string? additionalInformation, Exception innerException)
            : base(httpStatusCode, $"{_warningMessage} {additionalInformation}", innerException)
        {
        }
    }
}
