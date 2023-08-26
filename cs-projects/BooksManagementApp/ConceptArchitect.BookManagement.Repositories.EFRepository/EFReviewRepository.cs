using ConceptArchitect.Utils;
using ConceptArchitect.BookManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConceptArchitect.BookManagement.Repositories.EFRepository
{
    public class EFReviewRepository : IRepository<Review, string>
    {
        BMSContext context;
        public EFReviewRepository(BMSContext context)
        {
            this.context = context;
        }

        public async Task<Review> Add(Review entity)
        {
            context.Reviews.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(string id)
        {
            var author = await GetById(id);
            context.Reviews.Remove(author);
            await context.SaveChangesAsync();
        }


        public async Task<List<Review>> GetAll()
        {
            await Task.CompletedTask;
            return context.Reviews.ToList();
        }

        public async Task<List<Review>> GetAll(Func<Review, bool> predicate)
        {
            await Task.CompletedTask;
            var q = from author in context.Reviews
                    where predicate(author)
                    select author;

            return q.ToList();
        }

        public async Task<List<Review>> Search(string term)
        {
            await Task.CompletedTask;
            List<Review> author = context.Reviews.Where(a =>
                                                            a.ReviewDetails.Contains(term) ||
                                                            a.User.Name.Contains(term) ||
                                                            a.User.Email.Contains(term))
                                                            .ToList();
            return author;
        }
        public async Task<Review> GetById(string id)
        {
            await Task.CompletedTask;

            return context.Reviews.FirstOrDefault(a => a.Id == id);
        }

        public async Task<Review> Update(Review entity, Action<Review, Review> mergeOldNew)
        {
            var author = await GetById(entity.Id);
            if (author != null)
            {
                mergeOldNew(author, entity);
                await context.SaveChangesAsync();
            }

            return entity;
        }
    }
}
