using HungryHelper.Data;
using HungryHelper.Data.Entities;
using HungryHelper.Models.ShoppingList;

namespace HungryHelper.Services.ShoppingList
{
    public class ShoppingListService : IShoppingListService
    {
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