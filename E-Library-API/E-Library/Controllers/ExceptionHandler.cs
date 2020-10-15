using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace E_Library.Controllers
{
    [ApiController]
    public class ExceptionHandler:ControllerBase
    {
        private readonly ILogger _logger;
        public ExceptionHandler(ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
        }

        [Route("/error")]
        public IActionResult Handle()
        {
            var exceptionHandlerPathFeature =
                    HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if(exceptionHandlerPathFeature.Error == null)
            {
                return Ok();
            }

            var exception = exceptionHandlerPathFeature.Error;

            _logger.LogError($"Unhandled exception: {exception.Message}");

            return StatusCode(500);

        }
    }
}
