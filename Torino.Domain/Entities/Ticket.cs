using Torino.Domain.Enums;

namespace Torino.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public Guid TourId { get; private set; }
        public Tour? Tour { get; private set; }

        public Guid ReservatioanId { get; private set; }
        public Reservatioan? Reservatioan { get; private set; }

        public Guid UserId { get; private set; }
        public ApplicationUser? User { get; private set; }

        public TicketStatus TicketStatus { get; private set; }

        
        protected Ticket() { }

        
        public Ticket(
            Guid tourId,
            Guid reservationId,
            Guid userId,
            TicketStatus ticketStatus)
        {
            TourId = tourId;
            ReservatioanId = reservationId;
            UserId = userId;
            TicketStatus = ticketStatus;
        }
    }
}
