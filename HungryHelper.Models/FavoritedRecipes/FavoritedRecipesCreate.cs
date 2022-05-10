
using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.FavoritedRecipes
{
    public class FavoritedRecipesCreate
    {
        [Required]
        public int UserProfileId { get; set; }
        
        [Required]
        public int RecipeId { get; set; }
    }
}