using System.ComponentModel.DataAnnotations;

namespace PruebaFail.Web.Models
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombre y Apellido")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre { get; set; }
    }
}

