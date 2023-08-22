using Microsoft.AspNetCore.Mvc;

namespace BooksWeb02.Controllers
{
    public class BookController:Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
