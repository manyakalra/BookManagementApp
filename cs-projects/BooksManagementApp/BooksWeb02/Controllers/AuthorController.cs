using Microsoft.AspNetCore.Mvc;

namespace BooksWeb02.Controllers
{
    public class AuthorController:Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
