
using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.ShoppingList
{
    public class ShoppingListCreate
    {
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public string IngredientName { get; set; }

        public string Amount { get; set; }
    }
}