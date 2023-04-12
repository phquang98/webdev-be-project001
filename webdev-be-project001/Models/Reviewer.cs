using System.ComponentModel.DataAnnotations;

namespace webdev_be_project001.Models
{
    public class Reviewer
    {
        [Key]
        public int IdColumn { get; set; }
        public string FirstNameColumn { get; set; }
        public string LastNameColumn { get; set; }
        public ICollection<Review> ReviewClt { get; set; }
    }
}
