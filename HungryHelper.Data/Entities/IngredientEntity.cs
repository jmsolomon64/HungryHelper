using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Data.Entities
{
    public class IngredientEntity
    {
        [Key]
        public int Id {get; set;}
        [Required]
        [MaxLength(100)]
        public string Name {get; set;}
    }
}