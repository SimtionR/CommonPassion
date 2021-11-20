namespace CommonPassion_Backend.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AuthRequestModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
