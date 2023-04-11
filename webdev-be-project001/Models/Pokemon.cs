namespace webdev_be_project001.Models
{
    public class Pokemon
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<JoinPokemonOwner> PokemonOwners { get; set; }
        public ICollection<JoinPokemonCategory> PokemonCategories { get; set; }
    }
}
