using HungryHelper.Services.ShoppingList;
using Microsoft.AspNetCore.Mvc;
using HungryHelper.Models.ShoppingList;
using Microsoft.AspNetCore.Authorization;

namespace HungryHelper.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListService _service;
        public ShoppingListController(IShoppingListService service)
        {
            _service = service;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterShoppingList ([FromBody] ShoppingListCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _service.CreateShoppingListAsync (model);
            if (registerResult)
            {
                return Ok("A shopping list was create.");
            }

            return BadRequest("A shopping list could not be created.");
        }

        // [HttpGet("{userId:int}")]
        // public async Task<IActionResult> GetShoppingListByUserId ([FromRoute] int userId)
        // {
        //     var shoppingListResult = await _service.GetShoppingListByUserIdAsync(userId);

        //     if (shoppingListResult is null)
        //     {
        //         return NotFound();
        //     }

        //     return Ok(shoppingListResult);
        // }

        // [HttpPut("{userId:int}")]
        // public async Task<IActionResult> UpdateShoppingListById([FromForm] ShoppingListUpdate request)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     return await _service.UpdateShoppingListByIdAsync(request)
        //         ? Ok("Shopping list updated successfully.")
        //         : BadRequest("Shopping list could not be updated.");
        // }

    }
}
