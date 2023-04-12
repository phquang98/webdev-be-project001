using webdev_be_project001.Data;
using webdev_be_project001.Interfaces;
using webdev_be_project001.Models;

namespace webdev_be_project001.Repositories
{
    public class PokemonRepo : IPokemonRepo
    {
        private readonly DataCtx _ctx;

        public PokemonRepo(DataCtx ctx)
        {
            _ctx = ctx;
        }

        public ICollection<Pokemon> GetPokemonClt()
        {
            return _ctx.PokemonTable.OrderBy(poke => poke.ID).ToList();
        }

        public Pokemon GetPokemon(int idParam)
        {
            return _ctx.PokemonTable.Where(poke => poke.IdColumn == idParam).FirstOrDefault();
        }

        public Pokemon GetPokemon(string nameParam)
        {
            throw new NotImplementedException();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            throw new NotImplementedException();
        }

        public bool PokemonExists(int pokeId)
        {
            throw new NotImplementedException();
        }
    }
}
