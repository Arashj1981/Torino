using Torino.Application.Commands;
using Torino.Application.DTOs;

namespace Torino.Application.Interfaces
{
    public interface ITourService
    {
        Task<List<TourDto>> GetAllToursAsync();
        Task<TourDto?> GetTourByIdAsync(Guid id);
        Task<TourDto> CreateTourAsync(CreateTourCommand reateTourCommand);
        Task<TourDto> UpdateTourAsync(UpdateTourCommand updateTourCommand);
        Task DeleteTourAsync(Guid id);



    }
}
