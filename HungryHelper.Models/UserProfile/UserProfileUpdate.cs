using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.UserProfile
{
    public class UserProfileUpdate
    {
        [Required]
        public int Id { get; set;}
        public string CookingExperienceLevel { get; set;}
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string FavoriteFood { get; set;}
    }
}