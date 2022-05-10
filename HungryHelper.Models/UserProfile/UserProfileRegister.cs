using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.UserProfile
{
    public class UserProfileRegister
    {
        [Required]
        [MinLength(4)]
        public string Username { get; set;}
        [Required]
        [MinLength(4)]
        public string Password { get; set;}
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword {get; set;}
        [Required]
        public string CookingExperienceLevel { get; set;}
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string FavoriteFood { get; set;}
    }
}