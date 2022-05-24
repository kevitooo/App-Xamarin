using System.ComponentModel.DataAnnotations;

namespace PruebaFail.Common.Models
{
    public class UserRequest
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
    }
}

