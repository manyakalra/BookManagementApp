using BooksWeb02.ViewModels;
using ConceptArchitect.BookManagement;
using ConceptArchitect.Data;
using Microsoft.AspNetCore.Mvc;

namespace BooksWeb02.Controllers
{
    public class UserController : Controller
    {
        IUserService userService;

        public UserController(IUserService users)
        {
            this.userService = users;
        }

        public async Task<ViewResult> Index(string term)
        {
            List<User> users;
            if (term == null)
                users = await userService.GetAllUsers();
            else
            {
                ViewData["term"] = term;
                users = await userService.SearchUsers(term);
            }
            return View(users);
        }

        public async Task<ViewResult> Details(string id)
        {
            var user = await userService.GetUserById(id);

            return View(user);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View(new User());
        }

        [HttpPost]
        public async Task<ActionResult> Add(User user)
        {
            await userService.AddUser(user);

            return RedirectToAction("Index");
        }

        /*public async Task<ActionResult> Delete(string id)
        {
            await userService.DeleteUser(id);
            return RedirectToAction("Index");
        }*/
        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await userService.GetUserById(id);
            return View(user); //returns a View for confirmation
        }


        [HttpPost]
        public async Task<ActionResult> Delete(string id, string _)
        {
            await userService.DeleteUser(id);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Dropdown(string? selectedId, string? name)
        {
            var users = await userService.GetAllUsers();

            ViewBag.SelectedId = selectedId; //side optional information
            ViewBag.Name = name;
            return PartialView("_UserDropdown", users);
        }

        public async Task<List<User>> List()
        {
            var users = await userService.GetAllUsers();
            return users;
        }

        [HttpGet]
        public async Task<ViewResult> Update(string id)
        {
            var user = await userService.GetUserById(id);
            return View(new User()
            {
                Email = user.Email,
                Name= user.Name,
                Password = user.Password,
                Photo= user.Photo
            });
        }

        [HttpPost]
        public async Task<ActionResult> Update(User user)
        {
            await userService.UpdateUser(user);
            return RedirectToAction("Index");
        }
        public async Task<ViewResult> BooksByUser(string userId)
        {
            return await Index(userId);
        }

        [HttpGet]
        public ViewResult Login()
        {
            return View(new User());
        }
        [HttpPost]
        public async Task<ActionResult> Login(User user)
        {
            try
            {
                var response = await userService.GetUserById(user.Email);
            }
            catch (EntityNotFoundException ex)
            {
                return RedirectToAction("Login", "User", null);
            }
            HttpContext.Session.SetString("session", user.Email);
            return RedirectToAction("Index", "Home", null);
        }
    }
}