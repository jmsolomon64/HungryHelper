using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.Ingredient
{
    public class IngredientRegister //class used for registering Ingredients, holds the user generated data 
    {
        [Required]
        [MaxLength(100)]
        public string Name {get; set;} //class only holds data user generates so it is missing Ingredient Id
    }
}