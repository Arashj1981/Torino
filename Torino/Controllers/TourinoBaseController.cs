using Microsoft.AspNetCore.Mvc;
using Torino.Controllers;

namespace Torino.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public abstract class TourinoBaseController : ControllerBase  // abstract preventing this controller from being directly instantiated or used as an API endpoint.
    {
        protected IActionResult Respond(
              int statusCode,
              object? data = null
            , string? message = null
            , object? errors = null)
        {

            if (message == null)
            {
                if (statusCode == StatusCodes.Status200OK)
                    message = "موفقیت آمیز";
                else if (statusCode == StatusCodes.Status201Created)
                    message = "با موفقیت ایجاد شد";
                else if (statusCode == StatusCodes.Status400BadRequest)
                    message = "درخواست نامعتبر است";
                else if (statusCode == StatusCodes.Status401Unauthorized)
                    message = "دسترسی غیرمجاز است";
                else if (statusCode == StatusCodes.Status404NotFound)
                    message = "یافت نشد";
                else
                    message = "خطایی رخ داده است";
            }


            var response = new ApiResponse
            {
                Success = statusCode >= 200 && statusCode < 300,
                Message = message,
                Data = data,
            };

            return StatusCode(statusCode, response);
        }
    }

}
