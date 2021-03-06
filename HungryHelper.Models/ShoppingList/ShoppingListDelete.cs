
using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.ShoppingList
{
    public class ShoppingListDelete
    {
        [Required]
        public int ListId { get; set; }

        [Required]
        public string IngredientName { get; set; }
    }
}