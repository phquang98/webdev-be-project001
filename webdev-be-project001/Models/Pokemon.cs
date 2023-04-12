namespace webdev_be_project001.Models
{
    public class Pokemon
    {
        public int IdColumn { get; set; }
        public string NameColumn { get; set; }
        public DateTime DOBColumn { get; set; }
        public ICollection<Review> ReviewClt { get; set; }
        public ICollection<JoinPokemonOwner> PokemonOwnerClt { get; set; }
        public ICollection<JoinPokemonCategory> PokemonCategoryClt { get; set; }
    }
}
