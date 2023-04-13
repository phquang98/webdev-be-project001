using webdev_be_project001.Models;

namespace webdev_be_project001.Interfaces
{
    public interface IReviewerRepo
    {
        ICollection<Reviewer> GetReviewerClt();
        Reviewer GetReviewer(int reviewerIdParam);
        ICollection<Review> GetReviewCltByReviewer(int reviewerIdParam);
        bool ReviewerExists(int reviewerIdParam);
    }
}
