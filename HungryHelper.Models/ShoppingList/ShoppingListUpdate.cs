
using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.ShoppingList
{
    public class ShoppingListUpdate
    {
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public string IngredientName { get; set; }
    }
}