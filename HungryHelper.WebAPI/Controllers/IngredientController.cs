using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HungryHelper.Models.Ingredient;
using HungryHelper.Services.Ingredient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HungryHelper.WebAPI.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientServices _service; //creates instance of Iservice
        public IngredientController(IIngredientServices service) //dependency injection
        {
            _service = service;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterIngredient ([FromBody] IngredientRegister model)
        {
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var registResult = await _service.RegisterIngredientAsync(model);
                if (registResult)
                {
                    return Ok("Ingredient was registere");
                }

                return BadRequest("Ingredient couldn't be registered");
            }
        }
    }
}
