using Torino.Domain.Enums;

namespace Torino.Domain.Entities
{

    public class Comment : BaseEntity
    {

        public string Text { get; private set; } = string.Empty;   //متن کامنت کاربر

        
        public bool IsApproved { get; private set; } = false;

        public CommentStatus CommentStatus { get; private set; }//کامنت تایید شده  یا نه

        public ApplicationUser? User { get; private set; }   //هرآیدی چندتا نظر میزاره - هر نظر واسه یه آیدیه
        public string UserId { get; private set; } = Guid.NewGuid().ToString();


        public Tour? Tour { get; private set; }  //هرتور چندتا کامنت داره - هرکامنت فقط واسه یه توره}
        public Guid TourId { get; private set; }    //ایدی توری که کامنت راجبشه

        public Comment(
                string text,
                bool isApproved,
                CommentStatus commentStatus,
                string userId,
                Guid tourId)
        {
            Text = text;
            IsApproved = isApproved;
            CommentStatus = commentStatus;
            UserId = userId;
            TourId = tourId;
        }





    }


}
