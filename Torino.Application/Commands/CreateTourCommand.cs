using System.ComponentModel.DataAnnotations;
using Torino.Domain.Enums;

namespace Torino.Application.Commands
{
    public class CreateTourCommand
    {

        [Required]
        [StringLength(100)]
        public string TourOrigin { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Range(0, 120)]
        public int? MinAge { get; set; }

        [Range(0, 120)]
        public int? MaxAge { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Origin { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Destination { get; set; } = string.Empty;

        [Range(1, 365)]
        public int DurationDays { get; set; }

        [Required]
        public TourDifficulty TourDifficulty { get; set; }

        [Required]
        public TransportMode TransportMode { get; set; }

        [Required]
        public HotelRating TotelRating { get; set; }

        [Required]
        public TourType TourType { get; set; }

        [Range(0, 100000000000)]
        public decimal Price { get; set; }

        [Range(1, 1000)]
        public int Capacity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public bool IsSpecial { get; set; }
        public bool IsOneDay { get; set; }

        [StringLength(500)]
        public string BestSellingTours { get; set; } = string.Empty;

        [StringLength(500)]
        public string DomesticTour { get; set; } = string.Empty;

        [StringLength(500)]
        public string ForeignTour { get; set; } = string.Empty;
    }

    //93c8f7d7-5271-4e6e-be0c-0d9b6be1a718
    //98f32db0-c487-4983-be25-ce83635a513d
}
