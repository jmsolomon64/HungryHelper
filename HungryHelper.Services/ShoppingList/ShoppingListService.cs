using System.Security.Claims;
using HungryHelper.Data;
using HungryHelper.Data.Entities;
using HungryHelper.Models.ShoppingList;
using Microsoft.AspNetCore.Http;

namespace HungryHelper.Services.ShoppingList
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly int _userId; // establishing our _userId field
        public ShoppingListService(IHttpContextAccessor httpContextAccessor)
        {
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value; // This is getting the user claims
            var validId = int.TryParse(value, out _userId); // validate the claim value
                if (!validId) // Handling an invalid Id
                    throw new Exception("Attempted to build ShoppingListService without User Id claim.");
        }
        private readonly ApplicationDbContext _context;
        public ShoppingListService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateShoppingListAsync(ShoppingListCreate model)
        {
            var entity = new ShoppingListEntity
            {
                IngredientName = model.IngredientName,
                Amount = model.IngredientName,
                UtcAdded = DateTime.Now
            };

            _context.ShoppingList.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }
    }
}