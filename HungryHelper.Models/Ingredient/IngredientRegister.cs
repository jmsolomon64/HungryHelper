using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.Ingredient
{
    public class IngredientRegister
    {
        [Required]
        [MaxLength(100)]
        public string Name {get; set;}
    }
}