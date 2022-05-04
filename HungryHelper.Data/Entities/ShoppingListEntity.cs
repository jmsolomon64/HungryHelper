using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Data.Entities
{
    public class ShoppingListEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string IngredientName { get; set; }

        public string Amount { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }
        
        [Required]
        public int UserId { get; set; }
        // foreign key goes here
    }
}