using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torino.Domain.Entities;
using Torino.Domain.Interfaces;

namespace Torino.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;
        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(IEnumerable<Ticket> tickets)
        {
            await _context.Tickets.AddRangeAsync(tickets);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetTourTicketCountAsync(Guid tourId)
        {
           return await _context.Tickets
                .CountAsync(t => t.TourId == tourId);
        }

        public async Task<List<Ticket>> GetTicketsByReservationAsync(Guid reservationId)
        {
            return await _context.Tickets
                .Where(t => t.ReservatioanId == reservationId)
                .ToListAsync();
        }
    }
}
