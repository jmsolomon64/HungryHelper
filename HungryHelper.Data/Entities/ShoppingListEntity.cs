using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryHelper.Data.Entities
{
    public class ShoppingListEntity
    {
        [Key]
        public int ListId { get; set; }

        [Required]
        public string IngredientName { get; set; }

        public string Amount { get; set; }

        [Required]
        public DateTimeOffset UtcAdded { get; set; }

        public DateTimeOffset? UtcModified { get; set; }
        
        [Required]
        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }
        public UserProfileEntity Owner { get; set; } // Data relationship with User Profile
    }
}