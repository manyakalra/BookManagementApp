using ConceptArchitect.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ConceptArchitect.Collections.Extensions;
namespace CollectionTests
{
    public class BookCollectionTests
    {

     

        IIndexedList<Book> books;

        public BookCollectionTests()
        {
            BookDb db = new BookDb();
            books= db.Books;
        }


        [Fact]
        public void FindAll_CanFindBooksByAuthor()
        {
            var vivekBooks = books.Where(b => b.Author.Contains("Vivek"));

            Assert.Equal(2, vivekBooks.Length);
        }

        [Fact]
        public void Transform_CanGetAPriceList()
        {
            var prices = books.Select(b => b.Price);

            prices.ForEach((price, i) => Assert.Equal(books[i].Price, price));
        }

        [Fact]
        public void Transform_CanGetAuthorList()
        {
            books                           // IndexedList<Book>
                 .Select(b => b.Author)  //returns IndexedList<string>
                 .ForEach((author,i) => Assert.Equal(books[i].Author, author)); //works on IndexedList<String>
        }

        [Fact]
        public void Trasform_CanReturnListOfTitleAndPriceOnly()
        {
            var newList = books.Select(b => new { Title = b.Title, Price = b.Price });

            newList.ForEach((x, i) =>
            {
                Assert.Equal(books[i].Price, x.Price);
            });
            
        }

        [Fact]
        public void Transform_CanReturnTitleAndCostAdvise()
        {
            books
              .Select(b => new { Title = b.Title, IsExpensive = b.Price > 300 })
              .ForEach((x, i) => Assert.Equal(books[i].Price > 300, x.IsExpensive));

        }

        [Fact]
        public void CanFindTitleAndPriceOfHighRatedBooks()
        {
            var highRatedBookInfo =  books
                                        .Where(b=> b.Rating>4)
                                        .Select( b=> new {Title=b.Title, Price=b.Price });

            Assert.Equal(3, highRatedBookInfo.Length);
        }

       


        [Fact]
        public void CanFindTheTitleOfFirstHighRatedBook()
        {
            var title = books
                            .Where(b => b.Rating > 4)
                            .Select(b => b.Title)
                            .FindOne(b => true);

            Assert.Equal(books[0].Title, title);
        }

        [Fact]
        public void CanSortBooksOnPrice()
        {
            List<Book> bookList = new List<Book>();

            for(int i=0;i<books.Length;i++)
                bookList.Add(books[i]);

            var result = from b in bookList
                         where b.Rating>4
                         orderby b.Price
                         select  b;

            int lastPrice = 0;

            foreach(var book in result)
            {
                Assert.True(book.Price >= lastPrice);
                lastPrice = book.Price;
            }

        }

        [Fact]
        public void CanFindTitleAndRatingsOfHighPricedBooks()
        {
            var highRatedBookInfo = from b in books
                                    where b.Price > 300    // books.Where (b => b.Price>300)
                                    select new { Title = b.Title, Rating = b.Rating };

            Assert.Equal(3, highRatedBookInfo.Length);
        }

        [Fact]
        public void CanGetADistinctListOfAuthors()
        {
            var authors = books
                            .Select(b=>b.Author)
                            .Distinct();

            Assert.Equal(3, authors.Length);
        }

        [Fact]
        public void CanGetADistinctListOfAuthors2()
        {
            var authors = from b in books
                          select b;


            Assert.Equal(3, authors.Length);
        }


        [Fact]
        public void CanReturnAveragePriceOfHighRatedBooks()
        {
            var average = books
                             .Where(b => b.Rating > 4)
                             .Average(b => b.Price);

            Assert.Equal(332.33, average,2);
        }
    }
}
