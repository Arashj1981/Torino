using System.Data;
using Torino.Application.DTOs;
using Torino.Application.Interfaces;
using Torino.Domain.Entities;
using Torino.Domain.Enums;
using Torino.Domain.Interfaces;

namespace Torino.Application.Services
{
    public class TourFilterService : ITourFilterService
    {
        private readonly ITourRepository _tourRepository;

        public TourFilterService(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }

       

        public async Task<IReadOnlyList<TourDto>> FilterToursAsync(
            TourType? tourType,
            string? tourDestination,
            decimal? price,
            TransportMode? transportMode,
            int? durationDays
            )
        {
            tourDestination = tourDestination?.Trim();

            if (tourType == null && string.IsNullOrWhiteSpace(tourDestination) && price == null
                && transportMode == null && durationDays == null)
                throw new ArgumentException("At list one filter must be provided");

            var tours = await _tourRepository.FilterToursAsync(tourType, tourDestination, price, transportMode, durationDays);

            return tours.Select(MapToDto).ToList();
        }

        private static TourDto MapToDto(Tour tour) => new TourDto
        {
            Id = tour.Id,
            TourOrigin = tour.TourOrigin,
            Title = tour.Title,
            MinAge = tour.MinAge,
            MaxAge = tour.MaxAge,
            Description = tour.Description,
            Origin = tour.Origin,
            Destination = tour.Destination,
            DurationDays = tour.DurationDays,
            TourDifficulty = tour.TourDifficulty,
            TransportMode = tour.TransportMode,
            TotelRating = tour.TotelRating,
            TourType = tour.TourType,
            Price = tour.Price,
            Capacity = tour.Capacity,
            StartDate = tour.StartDate,
            EndDate = tour.EndDate,
            IsSpecial = tour.IsSpecial,
            IsOneDay = tour.IsOneDay,
            BestSellingTours = tour.BestSellingTours,
            DomesticTour = tour.DomesticTour,
            ForeignTour = tour.ForeignTour
        };


    }
}
