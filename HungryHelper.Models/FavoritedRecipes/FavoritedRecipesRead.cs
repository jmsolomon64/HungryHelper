
using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.FavoritedRecipes
{
    public class FavoritedRecipesRead
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserProfileId { get; set; }
        
        [Required]
        public int RecipeId { get; set; }
    }
}