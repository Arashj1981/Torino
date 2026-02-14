using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torino.Application.DTOs
{
    public class ReservationDto
    {
        public Guid Id { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfPepole { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = string.Empty;

        public List<TicketDto> Tickets { get; set; } = new();

    }
}
