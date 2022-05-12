using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.Recipe
{
    public class RecipeUpdate
    {
        [Required]
        [MaxLength(100)]
        public string CurrentName {get; set;}
        [Required]
        [MaxLength(100)]
        public string Category {get; set;}
        [Required]
        [MaxLength(100)]
        public string NewName {get; set;}
        [Required]
        [MaxLength(100000)]
        public string Directions {get; set;}
    }
}