using System.ComponentModel.DataAnnotations;

namespace PruebaFail.Common.Models
{
    public class EmailRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
