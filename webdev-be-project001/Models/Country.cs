using System.ComponentModel.DataAnnotations;

namespace webdev_be_project001.Models
{
    public class Country
    {
        [Key]
        public int IdColumn { get; set; }
        public string NameColumn { get; set; }
        public ICollection<Owner> OwnerClt { get; set; }
    }
}
