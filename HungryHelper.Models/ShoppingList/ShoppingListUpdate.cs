
using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.ShoppingList
{
    public class ShoppingListUpdate
    {
        [Required]
        public int ListId { get; set; }
        
        [Required]
        public string IngredientName { get; set; }

        public string Amount { get; set; }
    }
}