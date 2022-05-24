using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaFail.Web.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Nombre del producto")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Esta disponible?")]
        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Stock")]
        public double Stock { get; set; }

        public User User { get; set; }

        public PetType PetType { get; set; }

        public Owner Owner { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}