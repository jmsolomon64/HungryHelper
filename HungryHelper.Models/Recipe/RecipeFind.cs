using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.Recipe
{
    public class RecipeFind
    {
        [Required]
        [MaxLength(100)]
        public string Name {get; set;}
    }
}