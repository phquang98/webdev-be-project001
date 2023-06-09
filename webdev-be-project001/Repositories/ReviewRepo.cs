﻿using webdev_be_project001.Data;
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

        public bool CreaateReview(Review reviewDataParam)
        {
            _ctx.Add(reviewDataParam);
            return Save();
        }

        public bool DeleteReview(Review reviewDataParam)
        {
            _ctx.Remove(reviewDataParam);
            return Save();
        }

        public bool DeleteReviewClt(List<Review> reviewDataCltParam)
        {
            _ctx.RemoveRange(reviewDataCltParam);
            return Save();
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

        public bool Save()
        {
            var saved = _ctx.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateReview(Review reviewDataParam)
        {
            _ctx.Update(reviewDataParam);
            return Save();
        }
    }
}
