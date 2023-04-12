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

        public Pokemon GetPokemon(int idParam)
        {
            return _ctx.PokemonTable.Where(poke => poke.IdColumn == idParam).FirstOrDefault();
        }

        public Pokemon GetPokemon(string nameParam)
        {
            return _ctx.PokemonTable.Where(poke => poke.NameColumn == nameParam).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var review = _ctx.ReviewTable.Where(record => record.PokemonColumn.IdColumn == pokeId);
            Console.WriteLine(review);

            if (review.Count() <= 0)
            {
                return 0;
            }

            var soBiChia = review.Sum(poke => poke.RatingColumn);
            var soChia = review.Count();
            return ((decimal)review.Sum(rating => rating.RatingColumn) / review.Count());   
        }

        public bool PokemonExists(int pokeId)
        {
            return _ctx.PokemonTable.Any(poke => poke.IdColumn == pokeId);
        }
    }
}
