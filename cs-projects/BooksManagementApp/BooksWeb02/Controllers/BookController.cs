using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;

namespace BooksWeb02.Controllers
{
    public class BookController : Controller
    {
        IBookService bookService;
        public BookController(IBookService books)
        {
            this.bookService = books;
        }

        public async Task<ViewResult> Index()
        {
            var books = await bookService.GetAllBooks();
            return View(books);
        }

        public async Task<ViewResult> Favorites()
        {
            string userId = HttpContext.Session.GetString("session");
            var books = await bookService.GetAllFavorites(userId);

            return View(books);
        }

        public async Task<ActionResult> DeleteFavorites(string id)
        {
            string userId = HttpContext.Session.GetString("session");
            await bookService.DeleteFavorite(id, userId);

            return RedirectToAction("Favorites");
        }

        public async Task<ViewResult> Details(string id)
        {
            var book = await bookService.GetBookById(id);
            return View(book);
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

        public async Task<ActionResult> Delete(string id)
        {
            await bookService.DeleteBook(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ViewResult> Update(string id)
        {
            var book = await bookService.GetBookById(id);
            return View(book);
        }

        [HttpPost]
        public async Task<ActionResult> Update(Book book)
        {
            await bookService.UpdateBook(book);
            return RedirectToAction("Index");
        }

        public async Task<ViewResult> Search(string term)
        {
            var books = await bookService.SearchBooks(term);
            return View("Index", books);
        }

        [HttpGet]
        public async Task<ActionResult> AddToFavorites(string id)
        {
            string userId = HttpContext.Session.GetString("session");
            var book = await bookService.GetBookById(id);
            await bookService.AddFav(book, userId);

            return RedirectToAction("Favorites");
        }
        /*[HttpPost]
        public async Task<ActionResult> AddToFavorites(Book author)
        {
            await bookService.AddFav(author, "amit@gmail.com");

            return RedirectToAction("Favorites");
        }*/
    }
}