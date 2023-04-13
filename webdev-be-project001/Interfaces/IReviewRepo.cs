﻿using webdev_be_project001.Models;

namespace webdev_be_project001.Interfaces
{
    public interface IReviewRepo
    {
        ICollection<Review> GetReviewClt();
        Review GetReview(int reviewIdParam);
        ICollection<Review> GetReviewCltOfAPokemon(int pokeIdParam);
        bool ReviewExists(int reviewIdParam);
    }
}