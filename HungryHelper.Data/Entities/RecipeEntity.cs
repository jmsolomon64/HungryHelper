using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Data.Entities
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
        public List<int> Ingredients {get; set;} //intended to hold a list of foreign keys for ingredients
        [Required]
        public List<string> Measurements {get; set;}
        [Required]
        [MaxLength(100000)]
        public string Directions {get; set;}
        [Required]
        //needs to be made into a foreign key
        public int UserId {get; set;}
        [Required]
        public DateTime CreatedDate {get; set;} //stores the time the recipe was made
    }
}