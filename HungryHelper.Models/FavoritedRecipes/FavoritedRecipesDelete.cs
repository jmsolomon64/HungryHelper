
using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.FavoritedRecipes
{
    public class FavoritedRecipesDelete
    {
        [Required]
        public int Id { get; set; }

        // [Required]
        // public string RecipeId { get; set; }
    }
}