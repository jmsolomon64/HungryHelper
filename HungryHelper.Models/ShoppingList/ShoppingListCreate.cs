
using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.ShoppingList
{
    public class ShoppingListCreate
    {
        [Required]
        public string IngredientName { get; set; }
    }
}