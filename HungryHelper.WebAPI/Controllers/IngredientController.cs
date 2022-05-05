// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using HungryHelper.Services.Ingredient;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;

// namespace HungryHelper.WebAPI.Controllers
// {
//     [Route("api/[controller]")] 
//     [ApiController]
//     public class IngredientController : ControllerBase
//     {
//         private readonly IIngredientServices _service; //creates instance of Iservice
//         public IngredientController(IIngredientServices service) //dependency injection
//         {
//             _service = service;
//         }
//     }
// }
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
    { //All this controller does is make sure requests are valid from user and then sends the data off to the service layer
        private readonly IIngredientServices _service; //creates instance of Iservice
        public IngredientController(IIngredientServices service) //dependency injection
        {
            _service = service;
        }

        [HttpPost("Register")] //I think this means this method can be accessed through localhost/api/Ingredient/Register
        public async Task<IActionResult> RegisterIngredient ([FromBody] IngredientRegister model) //method I made to post a new Ingredient into the table 
        {
            {
                if(!ModelState.IsValid) //checks if Model state is not valid
                {
                    return BadRequest(ModelState); //response given if not valid
                }

                var registResult = await _service.RegisterIngredientAsync(model); //stores response of method used from Iservice (the one that makes new ingredients)
                if (registResult)
                {
                    return Ok("Ingredient was registered");
                }

                return BadRequest("Ingredient couldn't be registered");
            }
        }
    }
}
