using webdev_be_project001.Data;
using webdev_be_project001.Interfaces;
using webdev_be_project001.Models;

namespace webdev_be_project001.Repositories
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly DataCtx _ctx;

        public ReviewRepo(DataCtx ctxHere)
        {
            _ctx = ctxHere;
        }

        public Review GetReview(int reviewIdParam)
        {
            return _ctx.ReviewTable.FirstOrDefault(review => review.IdColumn == reviewIdParam);
        }

        public ICollection<Review> GetReviewClt()
        {
            return _ctx.ReviewTable.ToList();
        }

        public ICollection<Review> GetReviewCltOfAPokemon(int pokeIdParam)
        {
            return _ctx.ReviewTable
                .Where(review => review.PokemonColumn.IdColumn == pokeIdParam)
                .ToList();
        }

        public bool ReviewExists(int reviewIdParam)
        {
            return _ctx.ReviewTable.Any(review => review.IdColumn == reviewIdParam);
        }
    }
}
