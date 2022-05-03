
using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.FavoritedRecipes
{
    public class FavoritedRecipesRead
    {
        [Required]
        public int UserId { get; set; }
    }
}