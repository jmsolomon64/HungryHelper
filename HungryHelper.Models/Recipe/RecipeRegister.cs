using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.Recipe
{
    public class RecipeRegister
    {
        [Required]
        [MaxLength(100)]
        public string Category {get; set;}
        [Required]
        [MaxLength(100)]
        public string Name {get; set;}
        [Required]
        public List<int> Ingredients {get; set;} //intended to hold a list of foreign keys for ingredients
        [Required]
        public List<string> Measurements {get; set;}
        [Required]
        [MaxLength(100000)]
        public string Directions {get; set;}
    }
}