﻿using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement.Repositories.EFRepository
{
    public class EFBookRepository : IRepository<Book, string>
    {
        BMSContext context;
        public EFBookRepository(BMSContext context)
        {
            this.context = context;
        }

        public async Task<Book> Add(Book entity)
        {
            context.Books.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(string id)
        {
            var book = await GetById(id);
            context.Books.Remove(book);
            await context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAll()
        {
            await Task.CompletedTask;
            return context.Books.ToList();
        }

        public async Task<List<Book>> GetAll(Func<Book, bool> predicate)
        {
            await Task.CompletedTask;
            var q = from book in context.Books
                    where predicate(book)
                    select book;

            return q.ToList();
        }
        public async Task<List<Book>> Search(string term)
        {
            await Task.CompletedTask;
            List<Book> author = context.Books.Where(a => 
                                                a.Title.Contains(term) || 
                                                a.Description.Contains(term) || 
                                                a.Author.Name.Contains(term) ||
                                                a.AuthorId.Equals(term))
                                                .ToList();
            return author;
        }
        public async Task<Book> GetById(string id)
        {
            await Task.CompletedTask;

            return context.Books.FirstOrDefault(a => a.Id == id);
        }

        public async Task<Book> Update(Book entity, Action<Book, Book> mergeOldNew)
        {
            var book = await GetById(entity.Id);
            if (book != null)
            {
                mergeOldNew(book, entity);
                await context.SaveChangesAsync();
            }

            return entity;
        }
    }
}
