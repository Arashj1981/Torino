using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torino.Application.DTOs
{
    public class TicketDto
    {
        public Guid Id { get; set; }
        public Guid TourId { get; set; }
        public Guid ReservationId { get; set; }
        public Guid UserId { get; set; }
        public string TicketStatus { get; set; } = string.Empty;
    }
}
