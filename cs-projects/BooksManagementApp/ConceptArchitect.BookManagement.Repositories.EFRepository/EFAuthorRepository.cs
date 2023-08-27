﻿using ConceptArchitect.Utils;
using ConceptArchitect.BookManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement.Repositories.EFRepository
{
    public class EFAuthorRepository : IRepository<Author, string>
    {
        BMSContext context;
        public EFAuthorRepository(BMSContext context)
        {
            this.context = context;
        }

        public async Task<Author> Add(Author entity)
        {
            context.Authors.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public Task<Author> AddFavorite(Author entity, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(string id)
        {
            var author = await GetById(id);
            context.Authors.Remove(author);
            await context.SaveChangesAsync();
        }

        public Task DeleteFavorite(string bookId, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Author>> GetAll()
        {
            await Task.CompletedTask;
            return  context.Authors.ToList();
        }

        public async Task<List<Author>> GetAll(Func<Author, bool> predicate)
        {
            await Task.CompletedTask;
            var q= from author in context.Authors
                   where predicate(author)
                   select author;

            return q.ToList();
        }

        public Task<List<Author>> GetAllFavorites(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Author> GetById(string id)
        {
            await Task.CompletedTask;

            return context.Authors.FirstOrDefault(a => a.Id == id);
        }

        public async Task<Author> Update(Author entity, Action<Author, Author> mergeOldNew)
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
