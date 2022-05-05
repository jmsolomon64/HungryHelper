using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryHelper.Data.Entities //Holds what a Recipe will look like in the DB
{
    public class RecipeEntity
    {
        [Key]
        public int RecipeId {get; set;}
        [Required]
        [MaxLength(100)]
        public string Category {get; set;}
        [Required]
        [MaxLength(100)]
        public string Name {get; set;}
        public virtual ICollection<IngredientEntity> ListOfIngredients {get; set;}

        [Required]
        [MaxLength(100000)]
        public string Directions {get; set;}
        [Required]
        public DateTime CreatedDate {get; set;} //stores the time the recipe was made

        public RecipeEntity()
        {
            ListOfIngredients = new HashSet<IngredientEntity>();
        }
    }
}