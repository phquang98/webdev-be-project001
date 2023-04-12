using webdev_be_project001.Models;

namespace webdev_be_project001.Interfaces
{
    public interface IPokemonRepo
    {
        ICollection<Pokemon> GetPokemonClt();
        Pokemon GetPokemon(int idParam);
        Pokemon GetPokemon(string nameParam);
        decimal GetPokemonRating(int pokeId);
        bool PokemonExists(int pokeId);
    }
}
