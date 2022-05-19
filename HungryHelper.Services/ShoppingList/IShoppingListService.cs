
using HungryHelper.Models.ShoppingList;

namespace HungryHelper.Services.ShoppingList
{
    public interface IShoppingListService
    {
        Task<bool> CreateShoppingListAsync(ShoppingListCreate request);
        
        Task<IEnumerable<ShoppingListItem>> GetAllShoppingListByUserIdAsync();

        Task<bool> UpdateShoppingListAsync(ShoppingListUpdate request);

        Task<bool> DeleteShoppingListAsync(int ListId);
    }
}