using System.ComponentModel.DataAnnotations;

namespace EventManagementApp.Request
{
    public class AddUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(30)]
        public string Password { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
    }
}
