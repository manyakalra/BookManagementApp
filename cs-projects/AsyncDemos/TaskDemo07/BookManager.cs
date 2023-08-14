using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class BookManager
    {
        List<Book> books;

        public BookManager()
        {
            Book[] _books =
            {
                new Book() { Title = "The Accursed God", Author = "Vivek Dutta Mishra", Price = 299, Rating = 4.6 },
                new Book() { Title = "Manas", Author = "Vivek Dutta Mishra", Price = 199, Rating = 4.3 },
                new Book() { Title = "Asura", Author = "Anant Neelkanthan", Price = 399, Rating = 3.6 },
                new Book() { Title = "Ajaya", Author = "Anant Neelkanthan", Price = 499, Rating = 3.9 },
                new Book() { Title = "Immortals of Meluha", Author = "Amish", Price = 499, Rating = 4.8}

            };
            books = new List<Book>();

            foreach (var book in _books)
                books.Add(book);
        }

        public async Task<List<Book>> GetAllBooks()
        {
            await Task.Delay(1000);
            return books;  //automatically converted to Task<List<Book>>
        }


        public Task<List<Book>> GetAllBooksV1()
        {
            return Task.Factory.StartNew(()=> {
                Task.Delay(1000).Wait();
                return books;
            });
        }

        public async Task<Book> GetBookById(string title)
        {
           
            foreach (var book in books)
            {
                await Task.Delay(1000);
                if (book.Title == title)
                    return book; //returns Task<Book>
            }

            throw new Exception("Not Found");
           
        }

        public Task<Book> GetBookByIdV1(string title)
        {
            return Task.Factory.StartNew(() =>
            {
                foreach (var book in books)
                {
                    Task.Delay(1000).Wait();
                    if (book.Title == title)
                        return book;
                }
                    

                throw new Exception("Not Found");
            });
        }
    }
}
