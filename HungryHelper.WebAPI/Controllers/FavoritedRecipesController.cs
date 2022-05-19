using HungryHelper.Services.FavoritedRecipes;
using Microsoft.AspNetCore.Mvc;
using HungryHelper.Models.FavoritedRecipes;
using HungryHelper.Services.SeedData;

namespace HungryHelper.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritedRecipesController : ControllerBase
    {
        private readonly IFavoritedRecipesService _service;

        private readonly ISeedDataService _seed;

        public FavoritedRecipesController(IFavoritedRecipesService service, ISeedDataService seed)
        {
            _service = service;
            _seed = seed;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterFavoritedRecipes ([FromBody] FavoritedRecipesCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _service.CreateFavoritedRecipesAsync (model);
            if (registerResult)
            {
                return Ok("A favorite recipe was added.");
            }

            return BadRequest("A favorite recipe could not be added.");
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetFavoritedRecipesByUserId ([FromRoute] int userId)
        {
            await _seed.SeedFavoritedRecipesAsync(); // Calls method to add favorited recipes seed data to DB
            var favoritedRecipesResult = await _service.GetFavoritedRecipesByUserIdAsync(userId);

            if (favoritedRecipesResult is null)
            {
                return NotFound();
            }

            return Ok(favoritedRecipesResult);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteFavoritedRecipesById ([FromRoute] int id)
        {
            return await _service.DeleteFavoritedRecipesByIdAsync(id)
                ? Ok($"Favorite recipe {id} was deleted successfully.")
                : BadRequest($"Favorite recipe {id} could not be deleted.");        
        }
    }
}
