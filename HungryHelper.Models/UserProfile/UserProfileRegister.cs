using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.UserProfile
{
    public class UserProfileRegister
    {
        [Required]
        public string CookingExperienceLevel { get; set;}
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string FavoriteFood { get; set;}
    }
}