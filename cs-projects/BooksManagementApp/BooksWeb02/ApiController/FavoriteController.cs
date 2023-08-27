/*using BooksWeb02.ViewModels;
using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;
namespace BooksWeb02.ApiControllers
{
    [ApiController]
    [Route("/api/Favourites")]
    public class FavouriteController : Controller
    {
        IFavouriteService favouriteService;
        public FavouriteController(IFavouriteService favouriteService)
        { 
            this.favouriteService = favouriteService;
        }
        [HttpGet("{userEmail}", Name = "SelectedUserRoute")]
        public async Task<IActionResult> GetFavouriteByUserId(string userEmail)
        {
            var favourite = await favouriteService.GetFavouriteByUserId(userEmail);



            if (favourite != null)
                return Ok(favourite); //Status 200
            else
                return NotFound(favourite);  //Status 404
        }
        [HttpGet("{id}", Name = "SelectedFavouriteRoute")]
        public async Task<IActionResult> GetById(int id)
        {
            var favourite = await favouriteService.GetById(id);



            if (favourite != null)
                return Ok(favourite); //Status 200
            else
                return NotFound(favourite);  //Status 404
        }+
        [HttpPost]
        public async Task<IActionResult> AddFavourite(Favourite favourite)
        {
            await favouriteService.AddFavourite(favourite);



            return CreatedAtAction(nameof(GetById), new { Id = favourite.Id }, favourite);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavourite(int id)
        {
            await favouriteService.DeleteFavourite(id);



            return NoContent(); //204
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFavourite(string id, Favourite vm)
        {
            var favourite = new Favourite()
            {
                Id = vm.Id,

                BookId = vm.BookId,
                Status = vm.Status,
            };



            var result = await favouriteService.UpdateFavourite(favourite);



            return Accepted(result);
        }







    }
}*/