using Torino.Application.DTOs;
using Torino.Domain.Enums;

namespace Torino.Application.Interfaces;

public interface ITourFilterService
{

    Task<IReadOnlyList<TourDto>> FilterToursAsync(
        TourType? tourType,
        string? tourDestination,
        decimal? price,
        TransportMode? transportMode,
        int? durationDays
    );
}


