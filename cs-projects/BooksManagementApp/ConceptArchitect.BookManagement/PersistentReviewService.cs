using ConceptArchitect.Data;
using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConceptArchitect.BookManagement
{
    public class PersistentReviewService : IReviewService
    {

        IRepository<Review, string> repository;

        public PersistentReviewService(IRepository<Review, string> repository)
        {
            this.repository = repository;
        }

        public async Task<Review> AddReview(Review review)
        {
            if (review == null)
                throw new InvalidDataException("Review can't be null");

            if (string.IsNullOrEmpty(review.Id))
            {
                review.Id = await GenerateId(review.Title);
            }

            return await repository.Add(review);
        }

        private async Task<string> GenerateId(string title)
        {
            var id = title.ToLower().Replace(" ", "-");

            try
            {
                await repository.GetById(id);
            }
            catch (Exception ex)
            {
                if (ex is EntityNotFoundException)
                {
                    return id;
                }
            }

            int d = 1;
            while (await repository.GetById($"{id}-{d}") != null)
                d++;

            return $"{id}-{d}";
        }

        public async Task DeleteReview(string reviewId)
        {
            await repository.Delete(reviewId);
        }

        public async Task<List<Review>> GetAllReviews()
        {
            return await repository.GetAll();
        }

        public async Task<Review> GetReviewById(string id)
        {
            return await repository.GetById(id);
        }

        public async Task<List<Review>> SearchReviews(string term)
        {
            term = term.ToLower();
            return await repository.Search(term);
        }

        public async Task<Review> UpdateReview(Review review)
        {
            return await repository.Update(review, (old, newDetails) =>
            {
                old.Id = review.Id;
                old.Title = newDetails.Title;
                old.ReviewDetails = newDetails.ReviewDetails;
                old.User = newDetails.User;
                old.Book = newDetails.Book;
                old.Rating = newDetails.Rating;
            });
        }

    }
}
