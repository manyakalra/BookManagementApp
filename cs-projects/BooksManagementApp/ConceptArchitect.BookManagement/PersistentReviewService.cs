using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class PersistentReviewService : IReviewService
    {
        IRepository<Review, string> repository;

        public PersistentReviewService(IRepository<Review, string> repository)
        {
            this.repository = repository;
        }
        public async Task<Review> AddReview(Review Review)
        {
            return await repository.Add(Review);
        }

        public Task DeleteReview(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Review>> GetAllReviews()
        {
            return await repository.GetAll();
        }
    }
}
