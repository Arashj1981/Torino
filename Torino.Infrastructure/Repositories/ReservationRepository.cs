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
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Reservatioan reservation)
        {
            await _context.Reservatioans.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<Reservatioan?> GetByIdAsync(Guid id)
        {
            return await _context.Reservatioans.FindAsync(id);

        }

        public async Task<List<Reservatioan>> GetByUserIdAsync(string userId)
        {
            return await _context.Reservatioans
                .Where(r => r.UserId == userId)
                .Include(r => r.Tickets)
                .ToListAsync();

        }

        public async Task UpdateAsync(Reservatioan reservation)
        {
            _context.Reservatioans.Update(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<Reservatioan?> GetReservationWithDetailsAsync(Guid id)
        {
            return await _context.Reservatioans
                .Include(r => r.Tour)
                .Include(r => r.Tickets)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<bool> HasActiveReservationAsync(string userId, Guid tourId)
        {
            return await _context.Reservatioans
                .AnyAsync(r => r.UserId == userId &&
                              r.TourId == tourId &&
                              r.Status != "cancelled");
        }
    }
}
