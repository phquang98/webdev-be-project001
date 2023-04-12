using webdev_be_project001.Models;

namespace webdev_be_project001.Interfaces
{
    public interface IPokemonRepo
    {
        ICollection<Pokemon> GetPokemonClt();
        Pokemon GetPokemon(int pokeIdParam);
        Pokemon GetPokemon(string nameParam);
        decimal GetPokemonRating(int pokeIdHere);
        bool PokemonExists(int pokeIdHere);
    }
}
