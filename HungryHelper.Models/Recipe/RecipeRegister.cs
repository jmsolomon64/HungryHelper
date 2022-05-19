using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.Recipe
{
    //This class is used to collect the information needed to register a recipe that the user will give (everything except Id and DateTime)
    public class RecipeRegister
    {
        [Required]
        [MaxLength(100)]
        public string Category {get; set;}
        [Required]
        [MaxLength(100)]
        public string Name {get; set;}
        public List<string> ListOfIngredients {get; set;}
        [Required]
        [MaxLength(100000)]
        public string Directions {get; set;}
    }
}