using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BuberDinner.Application.Common.Errors;

namespace BuberDinner.API.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        [HttpPost]
        protected IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, message) = exception switch
            {
                DuplicateEmailException => (StatusCodes.Status409Conflict, "Email already exists"),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured")
            };

            return Problem(statusCode: statusCode, title: message);
        }
    }
}
