using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HungryHelper.Models.Recipe;
using HungryHelper.Services.Recipe;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HungryHelper.WebAPI.Controllers //This is on the client layer, topmost layer of this system
{
    [Route("api/[controller]")] //url that this controller can be accessed
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _service;  //instance of Iservice in API controller

        public RecipeController(IRecipeService service) //class constructor
        {
            _service = service; //injects the service ****ASK ABOUT DEPENDENCY INJECTION CAUSE I GOT NOTHING****
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

        [HttpGet("View")]
        public async Task<IActionResult> ViewAllRecipes()
        {

            return BadRequest("Invalid request");
        }

        [HttpGet("View/{id}")]
        public async Task<IActionResult> ViewRecipeById([FromRoute] int recipeId)
        {

            return BadRequest("Invalid Request");
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateRecipeById([FromBody] RecipeRegister model)
        {

            return BadRequest("Invalid Request");
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteRecipeById([FromRoute] int recipeId)
        {

            return BadRequest();
        }
    }
}
