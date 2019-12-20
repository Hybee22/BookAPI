using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.Models;

namespace BookApi.Services
{
    public class ReviewRepository : IReviewRepository
    {
        public Book GetBookOfAReview(int reviewId)
        {
            throw new NotImplementedException();
        }

        public Review GetReview(int reviewId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Review> GetReviews()
        {
            throw new NotImplementedException();
        }

        public ICollection<Review> GetReviewsOfABook(int bookId)
        {
            throw new NotImplementedException();
        }

        public bool ReviewsExist(int reviewId)
        {
            throw new NotImplementedException();
        }
    }
}
