using ConceptArchitect.BookManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TaskDemo07
{
    public class BookManagementTests
    {
        [Fact]
        public async void GetBookByIdReturnsBookByTitle()
        {
            var manager = new BookManager();
            var book =await  manager.GetBookById("Manas");

            Assert.NotNull(book);
        }
    }
}
