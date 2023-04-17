using webdev_be_project001.Models;

namespace webdev_be_project001.Interfaces
{
    public interface IPokemonRepo
    {
        ICollection<Pokemon> GetPokemonClt();
        Pokemon GetPokemon(int pokeIdParam);
        Pokemon GetPokemon(string nameParam);
        decimal GetPokemonRating(int pokeIdParam);
        bool PokemonExists(int pokeIdParam);
        bool CreatePokemon(int ownerIdParam, int cateIdParam, Pokemon pokemonParam);
        bool UpdatePokemon(int ownerIdParam, int cateIdParam, Pokemon pokemonParam);
        bool DeletePokemon(Pokemon pokemonParam);

        bool Save();
    }
}
