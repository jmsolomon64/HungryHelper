using HungryHelper.Services.FavoritedRecipes;
using Microsoft.AspNetCore.Mvc;
using HungryHelper.Models.FavoritedRecipes;

namespace HungryHelper.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritedRecipesController : ControllerBase
    {
        private readonly IFavoritedRecipesService _service;
        public FavoritedRecipesController(IFavoritedRecipesService service)
        {
            _service = service;
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

        [HttpGet("{userProfileId:int}")]
        public async Task<IActionResult> GetFavoritedRecipesByUserProfileId ([FromRoute] int userProfileId)
        {
            var favoritedRecipesResult = await _service.GetFavoritedRecipesByUserProfileIdAsync(userProfileId);

            if (favoritedRecipesResult is null)
            {
                return NotFound();
            }

            return Ok(favoritedRecipesResult);
        }
    }
}
