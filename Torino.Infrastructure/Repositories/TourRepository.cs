using Microsoft.EntityFrameworkCore;
using Torino.Domain.Entities;
using Torino.Domain.Enums;
using Torino.Domain.Interfaces;
using Torino.Infrastructure.Data;

namespace Torino.Infrastructure.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly ApplicationDbContext _context;

        public TourRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Tour tour)
        {
            await _context.AddAsync(tour);
            await _context.SaveChangesAsync();
        }


        public async Task<bool> DeleteAsync(Guid id)
        {
            var tour = await _context.Tours.FindAsync(id);

            if (tour == null) return false;

            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Tour>> GetAllAsync()
        {
            return await _context.Tours.ToListAsync();
        }

        public async Task<Tour?> GetByIdAsync(Guid id)
        {
            return await _context.Tours.FindAsync(id);
        }

        public async Task UpdateAsync(Tour tour)
        {
            var existingTour = await _context.Tours.FindAsync(tour.Id);
            if (existingTour == null)
                throw new KeyNotFoundException($" یافت نشد {tour.Id}توری با ایدی");

            _context.Entry(existingTour).CurrentValues.SetValues(tour);//
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tour>> FilterToursByDAndTAsync(TourType? tourType, string tourDestination)
        {
            var query = _context.Tours.AsQueryable();

            if (tourType.HasValue)
                query = query.Where(t => t.TourType == tourType.Value); // *******@@@@????

            if (!string.IsNullOrWhiteSpace(tourDestination))
                query = query.Where(t => t.Destination == tourDestination); //)(*&^%$#@

            return await query.ToListAsync();

        }

        public async Task<List<Tour>> FilterToursAsync(
            TourType? tourType,
            string? tourDestination,
            decimal? price,
            TransportMode? transportMode,
            int? durationDays)
        {
            var query = _context.Tours.AsQueryable();

            if (tourType.HasValue)
                query.Where(t => t.TourType == tourType);

            if (!string.IsNullOrWhiteSpace(tourDestination))
                query.Where(t => t.Destination == tourDestination);

            if (price.HasValue)
                query.Where(t => t.Price == price);

            if (transportMode.HasValue)
                query.Where(t => t.TransportMode == transportMode);

            if (durationDays.HasValue)
                query.Where(t => t.DurationDays == durationDays);

            return await query.ToListAsync();

            //var test = await _context.Tours.
            //    Where(item =>
            //          (tourType == null || item.TourType == tourType) && 
            //          (tourDestination == null || item.Destination == tourDestination)
            //    ).ToListAsync();
        }



        //Ai suggestion :

        // Check if tour exists
        //public async Task<bool> ExistsAsync(int id)
        //{
        //    return await _context.Tours.AnyAsync(t => t.Id == id);
        //}

        //public async Task<Tour?> GetByIdWithDetailsAsync(int id)
        //{
        //    return await _context.Tours
        //        .Include(t => t.Images)
        //        .Include(t => t.Category)
        //        .Include(t => t.Destination)
        //        .FirstOrDefaultAsync(t => t.Id == id);
        //}

    }
}
