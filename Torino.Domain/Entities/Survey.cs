using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torino.Domain.Entities
{
    public class Survey : BaseEntity                            //نظر سنجی
    {
                          //ایدی هر نظرسنجی

        public int Rating { get; private set; }                //امتیاز کاربر به تور

        public string FeedBack { get; private set; } = string.Empty;      //feedback کاربر واسه تور

        public string UserId { get; private set; } = Guid.NewGuid().ToString();
        //ایدی کاربری که این نظرو داده

        public ApplicationUser? User { get; private set; }                             //هر کاربر میتونه چندتا نظر بده - هرنظر واسه یه کاربره

        public Guid TourId { get; private set; }                           //ایدی توری که این نظر براش ثبت شده

        public Tour? Tour { get; private set; }                           //هر تور میتونه چندتا نظر داشته باشه - هر نظر واسه یه توره

        public Survey(
                int rating,
                string feedBack,
                string userId,
                Guid tourId)
        {
            Rating = rating;
            FeedBack = feedBack;
            UserId = userId;
            TourId = tourId;
        }


    }
}
