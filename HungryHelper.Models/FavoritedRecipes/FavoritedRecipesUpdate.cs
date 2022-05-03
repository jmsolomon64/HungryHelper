
using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.ShoppingList
{
    public class FavoritedRecipesUpdate
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string RecipeId { get; set; }
    }
}