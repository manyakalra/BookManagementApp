using ConceptArchitect.BookManagement;
using Xunit;

namespace ConceptArchitect.BookManaement.Tests
{
    public class AuthorManagerSpecs
    {
        AuthorManager authorManager;
        string validId = "vivek-dutta-mishra";
        string authorName = "Vivek Dutta Mishra";

        public AuthorManagerSpecs()
        {
            authorManager=new AuthorManager();
        }


        [Fact]
        public void GetAllAuthorsReturnsAllAuthors()
        {
            

            var authors = authorManager.GetAllAuthors();

            Assert.Equal(4, authors.Count);
        }

        [Fact]
        public void GetAuthorByIdReturnAuthorForValidId()
        {
            var author = authorManager.GetAuthorById(validId);

            Assert.NotNull(author);
            Assert.Equal(authorName, author.Name);

        }

        [Fact]
        public void GetAuthorByIdShouldFailForInvalidId()
        {
            Assert.Throws<InvalidIdException>(() => authorManager.GetAuthorById("invalid-id"));

            
        }

        
    }
}