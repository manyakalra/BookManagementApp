using BooksWeb02.ViewModels;
using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;

namespace BooksWeb02.Controllers
{
    public class BookController : Controller
    {
        IBookService bookService;
        IReviewService reviewService;

        public BookController(IBookService books, IReviewService reviewService)
        {
            this.bookService = books;
            this.reviewService = reviewService;
        }

        public async Task<ViewResult> Index(string term)
        {
            List<Book> books;
            if (term == null)
                books = books = await bookService.GetAllBooks();
            else
            {
                ViewData["term"] = term;
                books = await bookService.SearchBooks(term);
            }
            return View(books);
        }

        public async Task<ViewResult> BooksByAuthor(string id)
        {
            return await Index(id);
        }
        public async Task<ViewResult> Details(string id)
        {
            var book = await bookService.GetBookById(id);
            var reviews = await reviewService.SearchReviews(id);

            var bookReviews = new BookDetailReviewViewModel
            {
                Book = book,
                Reviews = reviews
            };
            return View(bookReviews);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View(new Book());
        }


        [HttpPost]
        public async Task<ActionResult> Add(Book book)
        {
            await bookService.AddBook(book);
            return RedirectToAction("Index");
        }

        /*public async Task<ActionResult> Delete(string id)
        {
            await bookService.DeleteBook(id);
            return RedirectToAction("Index");
        }
*/
        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            var book = await bookService.GetBookById(id);
            return View(book); //returns a View for confirmation
        }


        [HttpPost]
        public async Task<ActionResult> Delete(string id, string _)
        {
            await bookService.DeleteBook(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ViewResult> Update(string id)
        {
            var book = await bookService.GetBookById(id);
            return View(new Book()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                AuthorId = book.AuthorId,
                Cover = book.Cover
            });
        }

        [HttpPost]
        public async Task<ActionResult> Update(Book book)
        {
            await bookService.UpdateBook(book);
            return RedirectToAction("Index");
        }
    }
}