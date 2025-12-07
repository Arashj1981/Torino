using Torino.Domain.Entities;
using Torino.Domain.Enums;

namespace Torino.Domain.Interfaces
{
    public interface ITourRepository
    {
        Task<Tour?> GetByIdAsync(Guid id);

        Task<List<Tour>> GetAllAsync();

        Task AddAsync(Tour tour);

        Task UpdateAsync(Tour tour);
        Task<bool> DeleteAsync(Guid id);

        Task<List<Tour>> FilterToursAsync(
            TourType? tourType,
            string? tourDestination,
            decimal? price,
            TransportMode? transportMode,
            int? durationDays);


    }
}
