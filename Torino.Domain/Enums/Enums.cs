namespace Torino.Domain.Enums
{
    public enum TourDifficulty
    {
        Easy = 0,
        Moderate = 1,
        Hard = 2
    }
    public enum TransportMode
    {
        None = 0,
        Bus = 1,
        Train = 2,
        Flight = 3,
        Ship = 4,
        Van = 5
    }

    public enum HotelRating
    {
        Hostel = 0,
        OneStar = 1,
        TwoStar = 2,
        ThreeStar = 3,
        FourStar = 4,
        FiveStar = 5,
        Boutique = 6
    }

    public enum TourType
    {
        Domestic = 0,
        International = 1,
        Family = 2,
        Adventure = 3,
        Nature = 4,
        Cultural = 5,
        Religious = 6,
        Honeymoon = 7,
        SpecialEvent = 8,
        Camping = 9
    }

    public enum ReservationStatus
    {
        Pending = 0,
        Confirmed = 1,
        Cancelled = 2,
        Completed = 3
    }

    public enum TicketStatus
    {
        Issued = 0,
        Cancelled = 1,
        Used = 2,
        Expired = 3
    }

    public enum PaymentStatus
    {
        Pending = 0,
        Paid = 1,
        Failed = 2,
        Refunded = 3
    }

    public enum PaymentMethod
    {
        Cash = 0,
        Card = 1,
        OnlineGateway = 2,
        BankTransfer = 3,
        Wallet = 4
    }

    public enum UserRole
    {
        Customer = 0,
        Admin = 1,
        TourLeader = 2
    }

    public enum UserStatus
    {
        Active = 0,
        Suspended = 1,
        Deleted = 2
    }

    public enum CommentStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2
    }

    public enum PublishStatus
    {
        Draft = 0,
        Published = 1,
        Archived = 2
    }

    public enum ImageUsage
    {
        Primary = 0,
        Thumbnail = 1,
        Gallery = 2,
        Banner = 3
    }

    public enum SurveyQuestionType
    {
        SingleChoice = 0,
        MultipleChoice = 1,
        Rating = 2,
        Text = 3,
        YesNo = 4,
        Date = 5
    }

    public enum SurveyStatus
    {
        Draft = 0,
        Active = 1,
        Closed = 2,
        Archived = 3
    }

    public enum ReportPeriod
    {
        Daily = 0,
        Weekly = 1,
        Monthly = 2,
        Quarterly = 3,
        Yearly = 4
    }
}
