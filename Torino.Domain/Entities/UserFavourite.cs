using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torino.Domain.Entities
{
    public class UserFavourite : BaseEntity
    {
        public Guid TourId { get; private set; }
        public Tour? Tour { get; private set; }

        public string UserId { get; private set; } = Guid.NewGuid().ToString();

        public ApplicationUser? User { get; private set; }

        public UserFavourite(Guid tourId, string userId)
        {
            TourId = tourId;
            UserId = userId;
        }

    }
}



