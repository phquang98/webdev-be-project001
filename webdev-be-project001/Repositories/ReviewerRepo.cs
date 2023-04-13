using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using webdev_be_project001.Data;
using webdev_be_project001.Interfaces;
using webdev_be_project001.Models;

namespace webdev_be_project001.Repositories
{
    public class ReviewerRepo : IReviewerRepo
    {
        private readonly DataCtx _ctx;

        public ReviewerRepo(DataCtx ctxHere)
        {
            _ctx = ctxHere;
        }

        // TODO: notice this part, diff from other
        public ICollection<Review> GetReviewCltByReviewer(int reviewerIdParam)
        {
            return _ctx.ReviewTable
                .Where(reviewer => reviewer.ReviewerColumn.IdColumn == reviewerIdParam)
                .ToList();
        }

        public Reviewer GetReviewer(int reviewerIdParam)
        {
            return _ctx.ReviewerTable
                .Where(reviewer => reviewer.IdColumn == reviewerIdParam)
                .Include(e => e.ReviewClt)
                .FirstOrDefault();
        }

        public ICollection<Reviewer> GetReviewerClt()
        {
            return _ctx.ReviewerTable.ToList();
        }

        public bool ReviewerExists(int reviewerIdParam)
        {
            return _ctx.ReviewerTable.Any(reviewer => reviewer.IdColumn == reviewerIdParam);
        }
    }
}
