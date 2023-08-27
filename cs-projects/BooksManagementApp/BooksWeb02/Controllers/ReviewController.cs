using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;

namespace ReviewsWeb02.Controllers
{
    public class ReviewController : Controller
    {
        IReviewService reviewService;

        public ReviewController(IReviewService reviews)
        {
            this.reviewService = reviews;
        }

        public async Task<ViewResult> Index(string term)
        {
            List<Review> reviews;
            if (term == null)
                reviews = reviews = await reviewService.GetAllReviews();
            else
            {
                ViewData["term"] = term;
                reviews = await reviewService.SearchReviews(term);
            }
            return View(reviews);
        }

        public async Task<ViewResult> Details(string id)
        {
            var review = await reviewService.GetReviewById(id);
            return View(review);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View(new Review());
        }


        [HttpPost]
        public async Task<ActionResult> Add(Review review)
        {
            await reviewService.AddReview(review);
            return RedirectToAction("Index");
        }

        /*public async Task<ActionResult> Delete(string id)
        {
            await reviewService.DeleteReview(id);
            return RedirectToAction("Index");
        }
*/
        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            var review = await reviewService.GetReviewById(id);
            return View(review); //returns a View for confirmation
        }


        [HttpPost]
        public async Task<ActionResult> Delete(string id, string _)
        {
            await reviewService.DeleteReview(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ViewResult> Update(string id)
        {
            var review = await reviewService.GetReviewById(id);
            return View(new Review()
            {
                Id = review.Id,
                Title = review.Title,
                ReviewDetails = review.ReviewDetails,
                User = review.User,
                Rating = review.Rating
            });
        }

        [HttpPost]
        public async Task<ActionResult> Update(Review review)
        {
            await reviewService.UpdateReview(review);
            return RedirectToAction("Index");
        }
    }
}