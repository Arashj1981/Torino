using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torino.Application.Commands
{
    public class CreateReservationCommand
    {
        [Required]
        public Guid TourId { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Number of people must be greater than zero.")]
        public int NumberOfPepole { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Total price must be greater than zero.")]
        public decimal TotalPrice { get; set; }
 
        public DateTime? BookingDate { get; set; }
    }
}
