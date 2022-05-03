using HungryHelper.Services.FavoritedRecipes;
using Microsoft.AspNetCore.Mvc;

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
    }
