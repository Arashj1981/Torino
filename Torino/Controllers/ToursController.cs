using Microsoft.AspNetCore.Mvc;
using Torino.Application.Commands;
using Torino.Application.Exceptions;
using Torino.Application.Interfaces;

namespace Torino.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    
    public class ToursController : TourinoBaseController
    {
        private readonly ITourService _tourService;

        public ToursController(ITourService tourService)
        {
            _tourService = tourService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tours = await _tourService.GetAllToursAsync();
            return Respond(StatusCodes.Status200OK, tours);
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var tour = await _tourService.GetTourByIdAsync(id);
                return Respond(StatusCodes.Status200OK, tour);
            }
            catch (KeyNotFoundException)
            {
                return Respond(StatusCodes.Status404NotFound);
            }
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTourCommand command)
        {
            try
            {
                var createdTour = await _tourService.CreateTourAsync(command);
                return Respond(StatusCodes.Status201Created, createdTour);
            }
            catch (ValidationException ex)
            {
                return Respond(StatusCodes.Status400BadRequest, null, ex.Message);
            }
        }

        
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTourCommand command)
        {
            if (id != command.Id)
            {
                return Respond(StatusCodes.Status400BadRequest, null, "ID in URL does not match ID in body");
            }

            try
            {
                var updatedTour = await _tourService.UpdateTourAsync(command);
                return Respond(StatusCodes.Status200OK, updatedTour);
            }
            catch (KeyNotFoundException)
            {
                return Respond(StatusCodes.Status404NotFound);
            }
            catch (ValidationException ex)
            {
                return Respond(StatusCodes.Status400BadRequest, null, ex.Message);
            }
        }

        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _tourService.DeleteTourAsync(id);
                return Respond(StatusCodes.Status200OK, null, "Tour deleted successfully");
            }
            catch (KeyNotFoundException)
            {
                return Respond(StatusCodes.Status404NotFound);
            }
        }


    }
}
