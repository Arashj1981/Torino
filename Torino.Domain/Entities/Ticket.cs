using Torino.Domain.Enums;

namespace Torino.Domain.Entities
{
    public class Ticket : BaseEntity
    {

        public Guid TourId { get; private set; }
        public Tour? Tour { get; private set; }

        public Guid ReservatioanID { get; private set; }
        public Reservatioan? Reservatioan { get; private set; }

        public TicketStatus TicketStatus { get; private set; }

        public string UserId { get; private set; } = Guid.NewGuid().ToString();
        public ApplicationUser? User { get; private set; }

        public Ticket(
                Guid tourId,
                Guid reservatioanID,
                TicketStatus ticketStatus,
                string userId)
        {
            TourId = tourId;
            ReservatioanID = reservatioanID;
            TicketStatus = ticketStatus;
            UserId = userId;
        }

    }
}
