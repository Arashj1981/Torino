using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torino.Domain.Entities;

namespace Torino.Domain.Interfaces
{
    public interface ITicketRepository
    {
        Task<int> GetTourTicketCountAsync(Guid tourId);

        Task AddRangeAsync(IEnumerable<Ticket> tickets);
    }
}
