using Torino.Domain.Enums;

namespace Torino.Domain.Entities
{
    public class Tour : BaseEntity
    {
        /// <summary>
        /// شناسه
        /// </summary>

        public string TourOrigin { get; private set; } = string.Empty;
        public string Title { get; private set; } = string.Empty;              //عنوان تور
        public int? MinAge { get; private set; }
        public int? MaxAge { get; private set; }
        public string Description { get; private set; } = string.Empty;        //توضیحات کامل تور
        public string Origin { get; private set; } = string.Empty;     // or Airport/City entity
        public string Destination { get; private set; } = string.Empty; // or City/Country entity
        public int DurationDays { get; private set; }

        public TourDifficulty TourDifficulty { get; private set; }
        public TransportMode TransportMode { get; private set; }
        public HotelRating TotelRating { get; private set; }

        public TourType TourType { get; private set; }


        public decimal Price { get; private set; }                             //قیمت تور

        public int Capacity { get; private set; }                             //ظرفیت کل تور

        public DateTime StartDate { get; private set; }                       //شروع تور
        public DateTime EndDate { get; private set; }                         //پایان تور

        public bool IsSpecial { get; private set; }                           //تور ویژه
        public bool IsOneDay { get; private set; }                      //تور یک روزه

        public string BestSellingTours { get; private set; } = string.Empty;        //تورهای پرفروش

        public string DomesticTour { get; private set; } = string.Empty;       //تور داخلی 

        public string ForeignTour { get; private set; } = string.Empty;     //تور خارجی



        //public Guid CategoryId { get; set; }                        //شناسه دسته بندی تور

        //public Guid DestinationId { get; set; }                    //شناسه مقصد تور


        public ICollection<Comment> Comments { get; private set; } = new List<Comment>();

        public ICollection<UserFavourite> UserFavourites { get; private set; } = new List<UserFavourite>();

        public ICollection<Ticket> Tickets { get; private set; } = new List<Ticket>();
        public ICollection<Survey> Surveys { get; private set; } = new List<Survey>();
        public ICollection<TourImage> TourImages { get; private set; } = new List<TourImage>();

        public Tour(
                string tourOrigin,
                string title,
                int? minAge,
                int? maxAge,
                string description,
                string origin,
                string destination,
                int durationDays,
                TourDifficulty tourDifficulty,
                TransportMode transportMode,
                HotelRating totelRating,
                TourType tourType,
                decimal price,
                int capacity,
                DateTime startDate,
                DateTime endDate,
                bool isSpecial,
                bool isOneDay,
                string bestSellingTours,
                string domesticTour,
                string foreignTour
)
        {
            TourOrigin = tourOrigin;
            Title = title;
            MinAge = minAge;
            MaxAge = maxAge;
            Description = description;
            Origin = origin;
            Destination = destination;
            DurationDays = durationDays;
            TourDifficulty = tourDifficulty;
            TransportMode = transportMode;
            TotelRating = totelRating;
            TourType = tourType;
            Price = price;
            Capacity = capacity;
            StartDate = startDate;
            EndDate = endDate;
            IsSpecial = isSpecial;
            IsOneDay = isOneDay;
            BestSellingTours = bestSellingTours;
            DomesticTour = domesticTour;
            ForeignTour = foreignTour;
        }
        public void UpdateBasicInfo(
            string tourOrigin,
            string title,
            int? minAge,
            int? maxAge,
            string description,
            string origin,
            string destination,
            int durationDays,
            TourDifficulty tourDifficulty,
            TransportMode transportMode,
            HotelRating totelRating,
            TourType tourType,
            decimal price,
            int capacity,
            DateTime startDate,
            DateTime endDate,
            bool isSpecial,
            bool isOneDay,
            string bestSellingTours,
            string domesticTour,
            string foreignTour
        )
        {
            TourOrigin = tourOrigin;
            Title = title;
            MinAge = minAge;
            MaxAge = maxAge;
            Description = description;
            Origin = origin;
            Destination = destination;
            DurationDays = durationDays;
            TourDifficulty = tourDifficulty;
            TransportMode = transportMode;
            TotelRating = totelRating;
            TourType = tourType;
            Price = price;
            Capacity = capacity;
            StartDate = startDate;
            EndDate = endDate;
            IsSpecial = isSpecial;
            IsOneDay = isOneDay;
            BestSellingTours = bestSellingTours;
            DomesticTour = domesticTour;
            ForeignTour = foreignTour;
        }



    }

    //public TourCategory? Category { get; set; } //شی مربوط به تور - هر تور متعلق به یک دسته بندی 
    //public Destination? Destination { get; set; }              //مقصد مرتبط با این تور- هر تور مربوط به یک مقصد
    //public ICollection<TourImage> Images { get; set; } = new List<TourImage>(); //مقدار اولیه داده شده تا null نباشد
}
