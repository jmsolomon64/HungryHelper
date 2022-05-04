
using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.ShoppingList
{
    public class ShoppingListUpdate
    {
        [Required]
        public string IngredientName { get; set; }

        public string Amount { get; set; }
    }
}