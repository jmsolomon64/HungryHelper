using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HungryHelper.Data.Entities;
using HungryHelper.Models.Recipe;
using HungryHelper.Services.Recipe;
using HungryHelper.Services.SeedData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HungryHelper.WebAPI.Controllers //This is on the client layer, topmost layer of this system
{
    [Route("api/[controller]")] //url that this controller can be accessed
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _service;  //instance of Iservice in API controller

        private readonly ISeedDataService _seed;

        public RecipeController(IRecipeService service, ISeedDataService seed) //class constructor
        {
            _service = service; //injects the service 
            _seed = seed;
        }
        

        [HttpPost("Register")]  //Endpoint for api controller for post methods
        //Method for registering recipes, takes on data collected from RecipeRegister
        public async Task<IActionResult> RegisterRecipe([FromBody] RecipeRegister model) 
        {
            if (!ModelState.IsValid) //checks to see if not valid
            {
                return BadRequest(ModelState);
            }

            //variable holds results of method grabbed from service layer to register the recipe
            var registerResult = await _service.RegisterRecipeAsync(model);  
            if (registerResult)
            {
                return Ok("Recipe was registered"); 
            }

            return BadRequest("Recipe couldn't be added."); //catch all if neither other loops go off
        }

        [Authorize]
        [HttpGet("View/All")]
        public async Task<IActionResult> ViewAllRecipes()
        {
            await _seed.SeedRecipesAsync();
            List<RecipeEntity> recipes = _service.GetAllRecipes();

            if (recipes.Count > 0)
            {
                return Ok(recipes);
            }

            return BadRequest("Invalid request");
        }

        [Authorize]
        [HttpGet("View/Name")]
        public async Task<IActionResult> ViewRecipeByName([FromBody] RecipeFind model)
        {
            await _seed.SeedRecipesAsync();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recipeId = _service.FindRecipeByName(model.Name);
            if (recipeId <= 0)
            {
                return BadRequest("Recipe doesn't exist");
            }

            var recipe = _service.ViewRecipeByName(recipeId);

            return Ok(recipe);

            return BadRequest("Invalid Request");
        }
        
        [Authorize]
        [HttpPut("Update/Name")]
        public async Task<IActionResult> UpdateRecipeById([FromBody] RecipeUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int recipeId = _service.FindRecipeByName(model.CurrentName);
            bool successful = await _service.UpdateRecipeById(recipeId, model);

            if (successful)
            {
                return Ok("Changes made");
            }

            return BadRequest("Invalid Request");
        }


        [Authorize]
        [HttpDelete("Delete/Name")]
        public async Task<IActionResult> DeleteRecipeById([FromBody] RecipeFind model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int recipeId = _service.FindRecipeByName(model.Name);
            if (recipeId < 0)
            {
                return BadRequest("Recipe not found");
            }

            int rowsChanged = await _service.DeleteRecipeByIdAsync(recipeId);
            if (rowsChanged > 0)
            {
                return Ok("Recipe Deleted");
            }

            return BadRequest();
        }
    }
}
