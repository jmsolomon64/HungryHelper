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

            var numberOfChanges = await _dbContext.SaveChangesAsync();
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
        public async Task<bool> UpdateShoppingListAsync(ShoppingListUpdate request)
        {
            // Find the shopping list and validate it's owned by the user
            var entity = await _dbContext.ShoppingList.FindAsync(request.ListId);

            // By using the null conditional operator we can check if it's null at the same time we check the OwnerId
            if (entity?.OwnerId != _userId)
                return false;

            // Now we update the entity's properties
            entity.IngredientName = request.IngredientName;
            entity.Amount = request.Amount;
            entity.UtcModified = DateTimeOffset.Now;
            
            // Saves the changes to the database and captures how many rows were updated
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            // numberOfChanges is stated to be equal to 1 because only one row should be updated
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteShoppingListAsync(int ListId)
        {
            // Find the shopping list by the given Id
            var entity = await _dbContext.ShoppingList.FindAsync(ListId);

            // Validate the shopping list exists and is owned by the user
            if (entity?.OwnerId != _userId)
                return false;

            // Remove the shopping list from the DbContext and assert that the one change was saved
            _dbContext.ShoppingList.Remove(entity);
            return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}