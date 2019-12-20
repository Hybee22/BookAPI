using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.Models;

namespace BookApi.Services
{
    public class ReviewerRepository : IReviewerRepository
    {
        public Reviewer GetReviewer(int reviewerId)
        {
            throw new NotImplementedException();
        }

        public Reviewer GetReviewerOfAReview(int reviewId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            throw new NotImplementedException();
        }

        public ICollection<Reviewer> GetReviewsByReviewer(int reviewerId)
        {
            throw new NotImplementedException();
        }

        public bool ReviewersExist(int reviewerId)
        {
            throw new NotImplementedException();
        }
    }
}
