using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torino.Domain.Enums;

namespace Torino.Application.Commands
{
    public class CreateTicketCommand
    {
        [Required]
        public Guid TourId { get; set; }

        [Required]
        public Guid ReservatioanId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public TicketStatus TicketStatus { get; set; } = TicketStatus.Pending;
    }
}
