using ConceptArchitect.Data;
using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement.Repositories.Ado
{
    public class AdoReviewRepository : IRepository<Review, string>
    {
        DbManager db;
        public AdoReviewRepository(DbManager db)
        {
            this.db = db;
        }

        public async Task<Review> Add(Review review)
        {
            var query = $"insert into REVIEWS(reviewer_email,book_id,rating,title,details) " +
                              $"values('{review.ReviewerEmail}','{review.BookId}','{review.Rating}','{review.Title}','{review.Details}')";

            await db.ExecuteUpdateAsync(query);

            return review;
        }

        private Review ReviewExtractor(IDataReader reader)
        {
            return new Review()
            {
                ReviewerEmail = reader["reviewer_email"].ToString(),
                BookId = reader["book_id"].ToString(),
                Rating = Convert.ToInt32(reader["rating"]),
                Title = reader["rating"].ToString(),
                Details = reader["details"].ToString()
            };
        }
        public async Task<List<Review>> GetAll()
        {
            return await db.QueryAsync("select * from reviews", ReviewExtractor);
        }

        public async Task<List<Review>> GetAll(Func<Review, bool> predicate)
        {
            var reviews = await GetAll();

            return (from review in reviews
                    where predicate(review)
                    select review).ToList();

        }

        public Task<Review> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Review> Update(Review entity, Action<Review, Review> mergeOldNew)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Review>> GetAllFavorites(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Review> AddFavorite(Review entity, string userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFavorite(string bookId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
