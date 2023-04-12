using System.ComponentModel.DataAnnotations;

namespace webdev_be_project001.Models
{
    public class Owner
    {
        [Key]
        public int IdColumn { get; set; }
        public string NameColumn { get; set; }
        public string GymColumn { get; set; }
        public Country CountryColumn { get; set; }
        public ICollection<JoinPokemonOwner> PokemonOwnerClt { get; set; }
    }
}
