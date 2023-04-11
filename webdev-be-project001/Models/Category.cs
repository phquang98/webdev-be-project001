namespace webdev_be_project001.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<JoinPokemonCategory> PokemonCategories { get; set; }
    }
}
