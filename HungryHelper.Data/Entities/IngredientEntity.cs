using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Data.Entities
{
    public class IngredientEntity
    {
        [Key]
        public int IngredientId {get; set;} //will be generated automatically 
        [Required]
        [MaxLength(100)]
        public string Name {get; set;} //will be generated by user input

        public virtual ICollection<RecipeEntity> ListOfRecipes {get; set;}

        public IngredientEntity()
        {
            ListOfRecipes = new HashSet<RecipeEntity>(); //creates unique list of recipes ingredient is in
        }
    }
}