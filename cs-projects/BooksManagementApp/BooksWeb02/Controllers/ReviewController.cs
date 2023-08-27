using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;

namespace BooksWeb02.Controllers
{
    public class ReviewController : Controller
    {
        IReviewService reviewService;

        public ReviewController(IReviewService authors)
        {
            this.reviewService = authors;
        }
        public async Task<ViewResult> Index()
        {
            var books = await reviewService.GetAllReviews();

            return View(books);
        }
        
        [HttpGet]
        public async Task<ViewResult> AddReview(string id)
        {
            string userId = HttpContext.Session.GetString("session");
            await Task.Delay(500);
            Review review = new Review(){
                ReviewerEmail = userId,
                BookId = id
            };
            return  View("Add", review);
        }
        [HttpPost]
        public async Task<ActionResult> AddReview(Review review)
        {
            await reviewService.AddReview(review);
            return RedirectToAction("Index");
        }
    }
}
