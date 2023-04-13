using webdev_be_project001.Data;
using webdev_be_project001.Interfaces;
using webdev_be_project001.Models;

namespace webdev_be_project001.Repositories
{
    public class OwnerRepo : IOwnerRepo
    {
        private readonly DataCtx _ctx;

        public OwnerRepo(DataCtx ctxHere)
        {
            _ctx = ctxHere;
        }

        public Owner GetOwner(int ownerIdParam)
        {
            return _ctx.OwnerTable.FirstOrDefault(owner => owner.IdColumn == ownerIdParam);
        }

        public ICollection<Owner> GetOwnerClt()
        {
            return _ctx.OwnerTable.ToList();
        }

        public ICollection<Owner> GetOwnerOfAPokemon(int pokeIdParam)
        {
            // TODO: del later part to see what happen
            return _ctx.PokemonOwnerTable
                .Where(pokeOwn => pokeOwn.PokemonId == pokeIdParam)
                .Select(record => record.Owner)
                .ToList();
        }

        public ICollection<Pokemon> GetPokemonByOwner(int ownerIdParam)
        {
            return _ctx.PokemonOwnerTable
                .Where(pokeOwn => pokeOwn.Owner.IdColumn == ownerIdParam)
                .Select(record => record.Pokemon)
                .ToList();
        }

        public bool OwnerExists(int ownerIdParam)
        {
            return _ctx.OwnerTable.Any(owner => owner.IdColumn == ownerIdParam);
        }
    }
}
