using webdev_be_project001.Models;

namespace webdev_be_project001.Dto
{
    public class ReviewerDto
    {
        public int IdColumn { get; set; }
        public string FirstNameColumn { get; set; }
        public string LastNameColumn { get; set; }
        // fixed by Russian commenter in video 9 (in origin, he delete this line)
        public ICollection<ReviewDto> ReviewClt { get; set; }
    }
}
