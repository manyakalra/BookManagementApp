using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;

namespace BooksWeb02.Controllers
{
    public class AuthorController:Controller
    {
        IAuthorService authorService;

        public AuthorController(IAuthorService  authors)
        {
            this.authorService = authors;
        }

       
        public async Task<ViewResult> Index(string term)
        {
            List<Author> authors;
            if (term == null)
                authors = await authorService.GetAllAuthors();
            else
            {
                ViewData["term"] = term;
                authors = await authorService.SearchAuthors(term);
            }
            return View(authors);
        }
        
        public async Task<ViewResult> Details(string id)
        {
            var author = await authorService.GetAuthorById(id);

            return View(author);
        }


        [HttpGet]
        public ViewResult Add()
        {
            return View(new Author());
        }

        [HttpPost]
        public async Task<ActionResult> Add(Author author)
        {
            await authorService.AddAuthor(author);

            return RedirectToAction("Index");
        }

        /*public async Task<ActionResult> Delete(string id)
        {
            await authorService.DeleteAuthor(id);
            return RedirectToAction("Index");
        }*/
        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            var author = await authorService.GetAuthorById(id);
            return View(author); //returns a View for confirmation
        }


        [HttpPost]
        public async Task<ActionResult> Delete(string id, string _)
        {
            await authorService.DeleteAuthor(id);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Dropdown(string? selectedId, string? name)
        {
            var authors = await authorService.GetAllAuthors();

            ViewBag.SelectedId = selectedId; //side optional information
            ViewBag.Name = name;
            return PartialView("_AuthorDropdown", authors);
        }

        public async Task<List<Author>> List()
        {
            var authors = await authorService.GetAllAuthors();
            return authors;
        }

        [HttpGet]
        public async Task<ViewResult> Update(string id)
        {
            var author = await authorService.GetAuthorById(id);
            return View(new Author()
            {
                Id = author.Id,
                Name = author.Name,
                Biography = author.Biography,
                BirthDate = author.BirthDate,
                Email = author.Email,
                Photo = author.Photo
            });
        }

        [HttpPost]
        public async Task<ActionResult> Update(Author author)
        {
            await authorService.UpdateAuthor(author);
            return RedirectToAction("Index");
        }

    }
}
