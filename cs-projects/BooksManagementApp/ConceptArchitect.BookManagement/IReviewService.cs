using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public interface IReviewService
    {
        Task<List<Review>> GetAllReviews();
        Task<Review> AddReview(Review review);
        Task DeleteReview(int id);
    }
}
