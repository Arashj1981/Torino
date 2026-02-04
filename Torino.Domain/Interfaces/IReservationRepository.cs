using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torino.Domain.Entities;

namespace Torino.Domain.Interfaces
{
    public interface IReservationRepository
    {
        Task<Reservatioan?> GetByIdAsync(Guid id);

        Task<List<Reservatioan>> GetByUserIdAsync(string userId);

        Task AddAsync(Reservatioan reservation);

        Task UpdateAsync(Reservatioan reservation);


    }
}
