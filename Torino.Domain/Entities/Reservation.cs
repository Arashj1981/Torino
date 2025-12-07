using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torino.Domain.Entities;

namespace Torino.Domain.Entities
{
    public class Reservatioan : BaseEntity
    {



        public DateTime BookingDate { get; private set; } = DateTime.UtcNow; //ساعت رزرو

        public int NumberOfPepole { get; private set; }     //تعداد افرادی که رزرو شدن

        public decimal TotalPrice { get; private set; }    //قیمت کل رزرو = تعداد نفرات+قیمت تور

        public string Status { get; private set; } = "pending"; //وضعیت رزرو = در انتظار پرداخت -کنسل-پرداخت شده

        public ApplicationUser? User { get; private set; }
        public string UserId { get; private set; } = Guid.NewGuid().ToString();
        //ایدی که رزرو کرده

        public Tour? Tour { get; private set; }
        public Guid TourId { get; private set; }  //ایدی توری که رزرو شده

        public ICollection<Ticket>? Tickets { get; private set; }

        // public Payment? payment   //هر رزرو یک پرداخت یا پرداخت نشده

        public Reservatioan(
                DateTime bookingDate,
                int numberOfPepole,
                decimal totalPrice,
                string status,
                string userId,
                Guid tourId)
        {
            BookingDate = bookingDate;
            NumberOfPepole = numberOfPepole;
            TotalPrice = totalPrice;
            Status = status;
            UserId = userId;
            TourId = tourId;
        }


    }
}
