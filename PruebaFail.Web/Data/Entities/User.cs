using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PruebaFail.Web.Data.Entities
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Display(Name = "Nombre y Apellido")]
        public string Nombre { get; set; }
    }
}
