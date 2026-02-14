using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torino.Application.Commands;
using Torino.Application.DTOs;
using Torino.Application.Interfaces;
using Torino.Domain.Entities;

namespace Torino.Application.Services
{
    public class BookingService : IBookingService
    {
        public Task<ReservationDto> CancelReservationAsync(Guid reservationId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ReservationDto> ConfirmReservationAsync(Guid reservationId)
        {
            throw new NotImplementedException();
        }

        public async Task<ReservationDto> CreateReservationAsync(CreateReservationCommand command, string userId)
        {
            ValidateCommand(command);

            var reservation = new Reservatioan(
                command.BookingDate,
                command.NumberOfPepole,
                command.TotalPrice,
                command.UserId,
                command.TourId
                );
            
        }

        public Task<ReservationDto> GetReservationByIdAsync(Guid id, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ReservationDto>> GetUserReservationsAsync(string userId)
        {
            throw new NotImplementedException();
        }


        // Helpers

        private static void ValidateCommand(object command) 
        {
            var context = new ValidationContext(command);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(command, context, results, true);

            if (!isValid)
            {
                var errors = string.Join("; ", results.Select(r => r.ErrorMessage));
                throw new Exceptions.ValidationException(errors);
            }
        }
        

            private static ReservationDto? MapToDto(Reservatioan reservation)
        {
            if (reservation == null)
                return null;

            return new ReservationDto
            {
                Id = reservation.Id,
                BookingDate = reservation.BookingDate,
                NumberOfPepole = reservation.NumberOfPepole,
                TotalPrice = reservation.TotalPrice,
                Status = reservation.Status,
                Tickets = reservation.Tickets?.Select(t => new TicketDto
                {
                    Id = t.Id,
                    TourId = t.TourId,
                    ReservationId = t.ReservatioanId,
                    UserId = t.UserId,
                    TicketStatus = t.TicketStatus.ToString()
                }).ToList() ?? new List<TicketDto>()
            };
        }

    }


}

