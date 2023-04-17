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
            return _ctx.PokemonTable.OrderBy(poke => poke.IdColumn).ToList();
        }

        public Pokemon GetPokemon(int pokeIdParam)
        {
            return _ctx.PokemonTable.Where(poke => poke.IdColumn == pokeIdParam).FirstOrDefault();
        }

        public Pokemon GetPokemon(string nameParam)
        {
            return _ctx.PokemonTable.Where(poke => poke.NameColumn == nameParam).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeIdParam)
        {
            var review = _ctx.ReviewTable.Where(
                record => record.PokemonColumn.IdColumn == pokeIdParam
            );
            Console.WriteLine(review);

            if (review.Count() <= 0)
            {
                return 0;
            }

            var soBiChia = review.Sum(poke => poke.RatingColumn);
            var soChia = review.Count();
            return ((decimal)review.Sum(rating => rating.RatingColumn) / review.Count());
        }

        public bool PokemonExists(int pokeIdParam)
        {
            return _ctx.PokemonTable.Any(poke => poke.IdColumn == pokeIdParam);
        }

        public bool CreatePokemon(int ownerIdParam, int cateIdParam, Pokemon pokemonParam)
        {
            // pokemon depends on a PokemonOwner
            var pokemonOwnerRecord = _ctx.OwnerTable.FirstOrDefault(owner => owner.IdColumn == ownerIdParam);
            var pokemonOwnerTmp = new JoinPokemonOwner()
            {
                Owner = pokemonOwnerRecord,
                Pokemon = pokemonParam
            };
            _ctx.Add(pokemonOwnerTmp);

            // pokemon depends on a PokemonCategory
            var pokemonCategoryRecord = _ctx.CategoryTable.FirstOrDefault(cate => cate.IdColumn == cateIdParam);
            var pokemonCategoryTmp = new JoinPokemonCategory()
            {
                Category = pokemonCategoryRecord,
                Pokemon = pokemonParam
            };
            _ctx.Add(pokemonCategoryTmp);

            _ctx.Add(pokemonParam);

            return Save();
        }

        public bool Save()
        {
            var saved = _ctx.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePokemon(int ownerIdParam, int cateIdParam, Pokemon pokemonParam)
        {
            _ctx.Update(pokemonParam);
            return Save();
        }
    }
}
