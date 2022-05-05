using HungryHelper.Services.ShoppingList;
using Microsoft.AspNetCore.Mvc;

namespace HungryHelper.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListService _service;
        public ShoppingListController(IShoppingListService service)
        {
            _service = service;
        }
    }
}
