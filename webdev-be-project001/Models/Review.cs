using System.ComponentModel.DataAnnotations;

namespace webdev_be_project001.Models
{
    public class Review
    {
        [Key]
        public int IdColumn { get; set; }
        public string TitleColumn { get; set; }
        public string TextColumn { get; set; }
        public int RatingColumn { get; set; }
        public Reviewer ReviewerColumn { get; set; }
        public Pokemon PokemonColumn { get; set; }
    }
}
