using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryHelper.Data.Entities //Holds what a Recipe will look like in the DB
{
    public class RecipeEntity
    {
        [Key]
        public int Id {get; set;}
        [Required]
        [MaxLength(100)]
        public string Category {get; set;}
        [Required]
        [MaxLength(100)]
        public string Name {get; set;}
        [Required]
        [ForeignKey("Ingredient")]
        public List<int> Ingredients {get; set;} //intended to hold a list of foreign keys for ingredients
        [Required]
        public List<string> Measurements {get; set;}
        [Required]
        [MaxLength(100000)]
        public string Directions {get; set;}
        [Required]
        public DateTime CreatedDate {get; set;} //stores the time the recipe was made
    }
}