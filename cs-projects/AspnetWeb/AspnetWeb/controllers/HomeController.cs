using Microsoft.AspNetCore.Mvc;

namespace AspnetWeb.controllers
{
    public class HomeController:Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
