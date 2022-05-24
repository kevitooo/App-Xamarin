using System.ComponentModel.DataAnnotations;

namespace PruebaFail.Web.Models
{
    public class RecoverPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
