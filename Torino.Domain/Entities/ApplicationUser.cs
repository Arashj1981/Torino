using Microsoft.AspNetCore.Identity;
using Torino.Domain.Enums;

namespace Torino.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; private set; } = string.Empty;           //نام کاربر

        public string Fullname { get; private set; } = string.Empty;

        // email و passwordhash
        // توی همون identityuser 
        // وجود دارن و پاکشون کردم

        //public string Phonenumber { get; set; } = string.Empty;   i think identityuser has it
        public DateTime? CreatedAt { get; private set; }

        public UserRole UserRole { get; private set; } = UserRole.Customer; // رول دیفالت

        public DateTime? Brithdate { get; private set; }                     //تاریخ تولد کاربر

        public bool Passport { get; private set; } = false;                   //پاسپورت

        public int PassportNumber { get; private set; }

        public DateTime? PassportExpiryDate { get; private set; }

        public string NationalCode { get; private set; } = string.Empty;

        public string? CardNumber { get; private set; }

        public string? IBAN { get; private set; }

        public ICollection<Comment> Comments { get; private set; } = new List<Comment>();
        public ICollection<UserFavourite> UserFavourites { get; private set; } = new List<UserFavourite>();
        public ICollection<Reservatioan> Reservatioans { get; private set; } = new List<Reservatioan>();
        

        public ICollection<Survey> Surveys { get; private set; } = new List<Survey>();

        // Parameterless constructor for EF Core
        protected ApplicationUser() { }

        public ApplicationUser(
                string username,
                string email,
                string fullname,
                string name,
                UserRole userRole,
                DateTime? brithdate,
                bool passport,
                int passportNumber,
                DateTime? passportExpiryDate,
                string nationalCode,
                string? cardNumber,
                string? iban
)
        {
            UserName = username;
            Email = email;
            Fullname = fullname;
            Name = name;
            UserRole = userRole;
            Brithdate = brithdate;
            Passport = passport;
            PassportNumber = passportNumber;
            PassportExpiryDate = passportExpiryDate;
            NationalCode = nationalCode;
            CardNumber = cardNumber;
            IBAN = iban;

            CreatedAt = DateTime.UtcNow;
        }


    }
}

//1-رابطه یک به چند بین کاربر و رزروها  -یک کاربر میتواند چند رزرو داشته باشد
//2-هر کاربر میتواند چند نظر داشته باشد
//3-هرکاربر میتواند نظرسنجی داشته باشد
//4-کاربر میتواند چند لیست علاقه مندی داشته باشد
