
using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.ShoppingList
{
    public class ShoppingListRead
    {
        [Required]
        public int UserId { get; set; }
    }
}