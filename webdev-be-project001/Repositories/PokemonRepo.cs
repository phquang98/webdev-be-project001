using webdev_be_project001.Data;
using webdev_be_project001.Interfaces;
using webdev_be_project001.Models;

namespace webdev_be_project001.Repositories
{
    public class PokemonRepo: IPokemonRepo
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
    }
}
