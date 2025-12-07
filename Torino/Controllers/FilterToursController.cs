using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Torino.Application.Interfaces;
using Torino.Domain.Enums;
using Torino.WebApi.Controllers;

namespace Torino.Controllers
{
    public class FilterToursController : TourinoBaseController
    {


        private readonly ITourFilterService _tourFilterService;

        public FilterToursController(ITourFilterService tourFilterService)
        {
            _tourFilterService = tourFilterService;
        }
       
        [HttpGet("filter")]
        public async Task<IActionResult> FilterToursAsync(
            [FromQuery] TourType? tourType,
            [FromQuery] string? tourDestination,
            [FromQuery] decimal? price,
            [FromQuery] TransportMode? transportMode,
            [FromQuery] int? durationDays)
        {
            try
            {
                var result = await _tourFilterService.FilterToursAsync(
                    tourType,
                    tourDestination,
                    price,
                    transportMode,
                    durationDays);
                if (!result.Any())
                    return NotFound(new { message = "No tours found matching you" });

                return Respond(StatusCodes.Status200OK, result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", detail = ex.Message });
            }
        }

    }
}
