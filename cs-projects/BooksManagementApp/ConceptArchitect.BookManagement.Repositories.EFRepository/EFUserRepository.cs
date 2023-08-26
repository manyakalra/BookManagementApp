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
    public class EFUserRepository : IRepository<User, string>
    {
        BMSContext context;
        public EFUserRepository(BMSContext context)
        {
            this.context = context;
        }

        public async Task<User> Add(User entity)
        {
            context.Users.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(string id)
        {
            var author = await GetById(id);
            context.Users.Remove(author);
            await context.SaveChangesAsync();
        }


        public async Task<List<User>> GetAll()
        {
            await Task.CompletedTask;
            return context.Users.ToList();
        }

        public async Task<List<User>> GetAll(Func<User, bool> predicate)
        {
            await Task.CompletedTask;
            var q = from author in context.Users
                    where predicate(author)
                    select author;

            return q.ToList();
        }

        public async Task<List<User>> Search(string term)
        {
            await Task.CompletedTask;
            List<User> author = context.Users.Where(a =>
                                                            a.Name.Contains(term) ||
                                                            a.Email.Contains(term))
                                                            .ToList();
            return author;
        }
        public async Task<User> GetById(string id)
        {
            await Task.CompletedTask;

            return context.Users.FirstOrDefault(a => a.Email == id);
        }

        public async Task<User> Update(User entity, Action<User, User> mergeOldNew)
        {
            var author = await GetById(entity.Email);
            if (author != null)
            {
                mergeOldNew(author, entity);
                await context.SaveChangesAsync();
            }

            return entity;
        }
    }
}
