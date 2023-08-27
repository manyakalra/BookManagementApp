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
        Task<Review> GetReviewById(string id);
        Task<Review> AddReview(Review book);
        Task<Review> UpdateReview(Review book);
        Task DeleteReview(string bookId);
        Task<List<Review>> SearchReviews(string term);
    }
}