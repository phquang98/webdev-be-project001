namespace webdev_be_project001.Models
{
    public class Pokemon
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public ICollection<Review> ReviewClt { get; set; }
        public ICollection<JoinPokemonOwner> PokemonOwnerClt { get; set; }
        public ICollection<JoinPokemonCategory> PokemonCategoryClt { get; set; }
    }
}
