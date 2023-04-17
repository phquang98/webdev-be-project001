using webdev_be_project001.Models;

namespace webdev_be_project001.Interfaces
{
    public interface IReviewRepo
    {
        ICollection<Review> GetReviewClt();
        Review GetReview(int reviewIdParam);
        ICollection<Review> GetReviewCltOfAPokemon(int pokeIdParam);
        bool ReviewExists(int reviewIdParam);
        bool CreaateReview(Review reviewDataParam);
        bool UpdateReview(Review reviewDataParam);
        bool DeleteReview(Review reviewDataParam);
        bool DeleteReviewClt(List<Review> reviewDataCltParam);
        bool Save();
    }
}
