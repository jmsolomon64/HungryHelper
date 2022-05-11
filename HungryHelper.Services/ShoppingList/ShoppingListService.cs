using System.Security.Claims;
using HungryHelper.Data;
using HungryHelper.Data.Entities;
using HungryHelper.Models.ShoppingList;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HungryHelper.Services.ShoppingList
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly int _userId; // establishing our _userId field
        private readonly ApplicationDbContext _dbContext; // Injecting our DbContext instance and assigning it to a new field
        public ShoppingListService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
        {
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value; // This is getting the user claims
            var validId = int.TryParse(value, out _userId); // validate the claim value
                if (!validId) // Handling an invalid Id
                    throw new Exception("Attempted to build ShoppingListService without User Id claim.");

                _dbContext = dbContext;
        }
        private readonly ApplicationDbContext _context;
        public ShoppingListService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateShoppingListAsync(ShoppingListCreate request)
        {
            var shoppingListEntity = new ShoppingListEntity
            {
                IngredientName = request.IngredientName,
                Amount = request.Amount,
                UtcAdded = DateTimeOffset.Now,
                OwnerId = _userId
            };

            _dbContext.ShoppingList.Add(shoppingListEntity);

            var numberOfChanges = await _dbContext,SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<ShoppingListItem>> GetAllShoppingListByUserIdAsync()
        {
            var shoppingList = await _dbContext.ShoppingList
                .Where(entity => entity.OwnerId == _userId)
                .Select(entity => new ShoppingListItem
                {
                    Id = entity.ListId,
                    IngredientName = entity.IngredientName,
                    Amount = entity.Amount,
                    UtcCreated = entity.UtcAdded
                })
                .ToListAsync();

            return shoppingList; 
        }
        // public async Task<bool> CreateShoppingListAsync(ShoppingListCreate model)
        // {
        //     var entity = new ShoppingListEntity
        //     {
        //         IngredientName = model.IngredientName,
        //         Amount = model.IngredientName,
        //         UtcAdded = DateTime.Now
        //     };

        //     _context.ShoppingList.Add(entity);
        //     var numberOfChanges = await _context.SaveChangesAsync();

        //     return numberOfChanges == 1;
        // }
    }
}