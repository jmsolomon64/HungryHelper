using System.ComponentModel.DataAnnotations;

namespace HungryHelper.Models.Token
{
    public class TokenRequest
    {
        [Required]
        public string Username { get; set;}
        [Required]
        public string Password { get; set;}
    }
}