using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torino.Application.Interfaces;

namespace Torino.Application.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsService(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }
        

        public Task<int> GetTOtalUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
