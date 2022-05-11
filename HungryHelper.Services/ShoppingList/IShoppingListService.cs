
using HungryHelper.Models.ShoppingList;

namespace HungryHelper.Services.ShoppingList
{
    public interface IShoppingListService
    {
        Task<IEnumerable<ShoppingListItem>> GetAllShoppingListByUserIdAsync();
    }
}