using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torino.Domain.Interfaces;
using Torino.Infrastructure.Data;

namespace Torino.Infrastructure.Repositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly ApplicationDbContext _context;

        public StatisticsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    
        public async Task<int> GetTotalUsers()
        {
            return await _context.ApplicationUsers.CountAsync();
        }
    }
}
