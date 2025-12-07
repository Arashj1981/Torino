using Torino.Domain.Enums;

namespace Torino.Domain.Entities
{
    public class TourImage  : BaseEntity   //عکس تور

    {
                 //ایدی عکس
        public string ImageUrl { get; private set; } = string.Empty;

        public ImageUsage ImageUsage { get; private set; }

        public Guid TourId { get; private set; }          //ایدی توری که عکسشه

        public Tour? Tour { get; private set; }

        public TourImage(
            string imageUrl,
            ImageUsage imageUsage,
            Guid tourId)
        {
            ImageUrl = imageUrl;
            ImageUsage = imageUsage;
            TourId = tourId;
        }

    }

}
