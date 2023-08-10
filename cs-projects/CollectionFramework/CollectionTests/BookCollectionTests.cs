using ConceptArchitect.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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
            var vivekBooks = books.FindAll(b => b.Author.Contains("Vivek"));

            Assert.Equal(2, vivekBooks.Length);
        }

        [Fact]
        public void Transform_CanGetAPriceList()
        {
            var prices = books.Transform(b => b.Price);

            prices.ForEach((price, i) => Assert.Equal(books[i].Price, price));
        }

        [Fact]
        public void Transform_CanGetAuthorList()
        {
            books                           // IndexedList<Book>
                 .Transform(b => b.Author)  //returns IndexedList<string>
                 .ForEach((author,i) => Assert.Equal(books[i].Author, author)); //works on IndexedList<String>
        }

        [Fact]
        public void Trasform_CanReturnListOfTitleAndPriceOnly()
        {
            var newList = books.Transform(b => new { Title = b.Title, Price = b.Price });

            newList.ForEach((x, i) =>
            {
                Assert.Equal(books[i].Price, x.Price);
            });
            
        }

        [Fact]
        public void Transform_CanReturnTitleAndCostAdvise()
        {
            books
              .Transform(b => new { Title = b.Title, IsExpensive = b.Price > 300 })
              .ForEach((x, i) => Assert.Equal(books[i].Price > 300, x.IsExpensive));

        }

        [Fact]
        public void CanFindTitleAndPriceOfHighRatedBooks()
        {
            var highRatedBookInfo =  books
                                        .FindAll(b=> b.Rating>4)
                                        .Transform( b=> new {Title=b.Title, Price=b.Price });

            Assert.Equal(3, highRatedBookInfo.Length);
        }


        [Fact]
        public void CanFindTheTitleOfFirstHighRatedBook()
        {
            var title = books
                            .FindAll(b => b.Rating > 4)
                            .Transform(b => b.Title)
                            .FindOne(b => true);

            Assert.Equal(books[0].Title, title);
        }
    }
}
