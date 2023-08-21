using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AspnetWeb
{
    public class EcolabController : Controller
    {
        private AuthorManager manager;

        public EcolabController(AuthorManager manager)
        {
            this.manager = manager;
        }


        public ViewResult Home()
        {
            return View();
        }


        public ViewResult DateAndTime()
        {
            ViewBag.Date = DateTime.Now;
            return View();
        }

        public ViewResult Today()
        {
            var date = DateTime.Now;

            return View("DateTimeView",date); //pass view name and model
        }

        public ViewResult Tomorrow()
        {
            var date = DateTime.Now.AddDays(1);

            return View("DateTimeView", date);
        }

        public ViewResult After(int days)
        {
            var date = DateTime.Now.AddDays(days);
            return View("DateTimeView", date);
        }

        public ViewResult AfterDays(int id)
        {
            var date = DateTime.Now.AddDays(id);
            return View("DateTimeView", date);
        }


        public ContentResult AuthorList()
        {
            var html = new StringBuilder();
            html.Append("<html><head><title>Book's Web</title></head>");
            html.Append("<body><h1>Author List</h1>");
            html.Append("<table><thead><tr><th>Image</th></td></thead>");
            html.Append("<tbody>");

            var authors = manager.GetAllAuthors();

            foreach(var author in authors)
            {
                html.Append($"<tr><td><img src='{author.Photo}' height='100'/></td><td>{author.Name}</td></tr>");
            }

            html.Append("</tbody></table></body></html>");

            return new ContentResult()
            {
                Content = html.ToString(),
                ContentType = "text/html"
            };           

        }


        public ViewResult Authors()
        {
            var authors = manager.GetAllAuthors();

            return View(authors);
        }



        //  /ecolab/welcome
        public string Welcome()
        {
            return "Hello! Welcome to Ecolab Server";
        }

        // /ecolab/timeserver
        public DateTime TimeServer()
        {
            return DateTime.Now;
        }

        // /ecolab/contact
        public User Contact()
        {
            return new User()
            {
                Name = "Vivek Dutta Mishra",
                Email = "vivek@conceptarchitect.in"
            };
        }
    
    
    }
}
