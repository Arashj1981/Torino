using System.ComponentModel.DataAnnotations;
using Torino.Application.Commands;
using Torino.Application.DTOs;
using Torino.Application.Interfaces;
using Torino.Domain.Entities;
using Torino.Domain.Enums;
using Torino.Domain.Interfaces;

namespace Torino.Application.Services
{
    public class TourService : ITourService
    {
        private readonly ITourRepository _tourRepository;

        public TourService(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }

        public async Task<TourDto> CreateTourAsync(CreateTourCommand command)
        {
            ValidateCommand(command);

            var tour = new Tour(command.TourOrigin,
                command.Title,
                command.MinAge,
                command.MaxAge,
                command.Description,
                command.Origin,
                command.Destination,
                command.DurationDays,
                command.TourDifficulty,
                command.TransportMode,
                command.TotelRating,
                command.TourType,
                command.Price,
                command.Capacity,
                command.StartDate,
                command.EndDate,
                command.IsSpecial,
                command.IsOneDay,
                command.BestSellingTours,
                command.DomesticTour,
                command.ForeignTour);
            await _tourRepository.AddAsync(tour);
            return MapToDto(tour);
        }

        public async Task DeleteTourAsync(Guid id)
        {
            var deleted = await _tourRepository.DeleteAsync(id);
            if (!deleted)
                throw new KeyNotFoundException($"Tour with ID {id} not found.");
        }

        public async Task<List<TourDto>> GetAllToursAsync()
        {
            var tours = await _tourRepository.GetAllAsync();
            return tours.Select(MapToDto).ToList();
        }

        public async Task<TourDto?> GetTourByIdAsync(Guid id)
        {
            var tour = await _tourRepository.GetByIdAsync(id);
            if (tour == null)
            {
                throw new KeyNotFoundException($"Tour with ID {id} not found.");
            }
            var tourDto = MapToDto(tour);
            return tourDto;
        }

        public async Task<TourDto> UpdateTourAsync(UpdateTourCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var tour = await _tourRepository.GetByIdAsync(command.Id);

            if (tour == null)
                throw new KeyNotFoundException($"Tour with ID {command.Id} not found.");

            tour.UpdateBasicInfo(
                command.TourOrigin,
                command.Title,
                command.MinAge,
                command.MaxAge,
                command.Description,
                command.Origin,
                command.Destination,
                command.DurationDays,
                command.TourDifficulty,
                command.TransportMode,
                command.TotelRating,
                command.TourType,
                command.Price,
                command.Capacity,
                command.StartDate,
                command.EndDate,
                command.IsSpecial,
                command.IsOneDay,
                command.BestSellingTours,
                command.DomesticTour,
                command.ForeignTour
            );

            await _tourRepository.UpdateAsync(tour);
            return MapToDto(tour);
        }




        //متد کمک کننده:

        private static void ValidateCommand(object command) // **************????????$$$$$$$$$$$
        {
            var context = new ValidationContext(command);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(command, context, results, true);

            if (!isValid)
            {
                var errors = string.Join("; ", results.Select(r => r.ErrorMessage));
                throw new Exceptions.ValidationException(errors);
            }
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

        public async Task<IReadOnlyList<TourDto>> FilterToursAsync(TourType? tourType,
            string? tourDestination , decimal price , TransportMode? transportMode ,
            int durationDays)
        {
            tourDestination = tourDestination?.Trim();

            if (tourType == null && string.IsNullOrWhiteSpace(tourDestination))
                throw new ArgumentException("At least one filter type or destination must be provided.");

            var tours = await _tourRepository.FilterToursAsync( tourType,
                tourDestination , price,  transportMode , durationDays);

            return tours.Select(MapToDto).ToList();
        }
    }
}
