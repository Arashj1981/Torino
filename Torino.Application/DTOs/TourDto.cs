using Torino.Domain.Enums;

namespace Torino.Application.DTOs
{
    public class TourDto
    {
        public Guid Id { get; set; }
        public string TourOrigin { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public int DurationDays { get; set; }
        public TourDifficulty TourDifficulty { get; set; }
        public TransportMode TransportMode { get; set; }
        public HotelRating TotelRating { get; set; }
        public TourType TourType { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsSpecial { get; set; }
        public bool IsOneDay { get; set; }
        public string BestSellingTours { get; set; } = string.Empty;
        public string DomesticTour { get; set; } = string.Empty;
        public string ForeignTour { get; set; } = string.Empty;

    }
}
