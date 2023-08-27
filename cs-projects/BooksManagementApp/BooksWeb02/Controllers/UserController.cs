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

        public async Task<ViewResult> Index()
        {
            var users = await userService.GetAllUsers();

            return View(users);
        }

        public async Task<ViewResult> Details(string id)
        {
            var user = await userService.GetUserById(id);

            return View(user);
        }
        public async Task<ViewResult> Search(string term)
        {
            var response = await userService.SearchUser(term);
            return View("Index", response);
        }
        public async Task<ActionResult> Delete(string id)
        {
            await userService.DeleteUser(id);

            return RedirectToAction("Index");
        }
        public async Task<ViewResult> Edit(string id)
        {
            var user = await userService.GetUserById(id);
            return View(user);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(User user)
        {
            await userService.UpdateUser(user);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View("Register", new User());
        }
        

        [HttpPost]
        public async Task<ActionResult> Add(User user)
        {
            await userService.AddUser(user);

            return RedirectToAction("Index", "Home", null);
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
