using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Data.Entities

{
    public class UserProfileEntity
    {
        [Key]
        public int Id { get; set;}
        [Required]
        public DateTime DateJoined { get; set;}
        [Required]
        public string CookingExperienceLevel { get; set;}
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string FavoriteFood { get; set;}
        public List<ShoppingListEntity> ShoppingList { get; set; } // Data relationship with Shopping List
    }
}