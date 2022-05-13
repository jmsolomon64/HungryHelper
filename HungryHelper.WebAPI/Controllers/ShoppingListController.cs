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

        // POST api/ShoppingList
        [HttpPost]
        public async Task<IActionResult> CreateShoppingListAsync([FromBody] ShoppingListCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _service.CreateShoppingListAsync(request))
                return Ok("Shopping list created successfully.");

            return BadRequest("Shopping list could not be created.");
        }

        // GET api/ShoppingList
        [HttpGet]
        public async Task<IActionResult> GetAllShoppingListByUserId ([FromRoute] int userId)
        {
            var shoppingList = await _service.GetAllShoppingListByUserIdAsync();
            return Ok(shoppingList);
        }

        // PUT api/ShoppingList
        [HttpPost]
        public async Task<IActionResult> UpdateShoppingListById([FromBody] ShoppingListUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            return await _service.UpdateShoppingListAsync(request)
                ? Ok("Shopping list updated successfully.")
                : BadRequest("Shopping list could not be updated.");
        }
    }
}
