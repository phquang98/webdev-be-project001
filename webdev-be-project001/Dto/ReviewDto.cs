using webdev_be_project001.Models;

namespace webdev_be_project001.Dto
{
    public class ReviewDto
    {
        public int IdColumn { get; set; }
        public string TitleColumn { get; set; }
        public string TextColumn { get; set; }
        public int RatingColumn { get; set; }
    }
}
