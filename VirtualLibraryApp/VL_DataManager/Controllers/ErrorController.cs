using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VL_DataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        private IConfiguration _configuration;
        public ErrorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error.Message;
            var code = 500;
            string message = _configuration.GetSection("AppSettings:ErrorMsg").Value;

            Response.StatusCode = code;

            return Problem(exception, null, code, message);
        }
    }
}
