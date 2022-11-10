using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectV2.Common.Exceptions;

namespace ProjectV2.API.Controllers
{
    [ApiController]
    [ApiExceptionFilter]
    public abstract class AppBaseController : ControllerBase
    {
    }
}
