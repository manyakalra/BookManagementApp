using ConceptArchitect.BookManagement;
namespace BooksWeb02.ViewModels
{
    public class BookDetailReviewViewModel
    {
        public Book Book {  get; set; }
        public List<Review> Reviews { get; set; }
    }
}
