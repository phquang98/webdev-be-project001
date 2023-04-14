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

        public bool CreateReviewer(Reviewer reviewerDataParam)
        {
            _ctx.Add(reviewerDataParam);
            return Save();
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

        public bool Save()
        {
            var saved = _ctx.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
