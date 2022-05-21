
using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.ShoppingList
{
    public class ShoppingListCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(8000, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string IngredientName { get; set; }
        
        // [Required]
        // [MinLength(2, ErrorMessage = "{0} must be at least {1} characters long.")]
        // [MaxLength(100, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string Amount { get; set; }
    }
}