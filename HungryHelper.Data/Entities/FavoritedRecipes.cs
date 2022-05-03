using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Data.Entities
{
    public class FavoritedRecipes
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int UserId { get; set; }
        // foreign key goes here

        [Required]
        public int RecipeId { get; set; }
        // foreign key goes here
    }
}