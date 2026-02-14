using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torino.Application.Commands;
using Torino.Application.DTOs;

namespace Torino.Application.Interfaces
{
    public interface IBookingService
    {
        Task<ReservationDto> CreateReservationAsync(CreateReservationCommand command, string userId);
        Task<ReservationDto> CancelReservationAsync(Guid reservationId, string userId);
        Task<List<ReservationDto>> GetUserReservationsAsync(string userId);
        Task<ReservationDto> GetReservationByIdAsync(Guid id, string userId);
        Task<ReservationDto> ConfirmReservationAsync(Guid reservationId); // admin

    }
}
