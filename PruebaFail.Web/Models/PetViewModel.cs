using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using PruebaFail.Web.Data.Entities;

namespace PruebaFail.Web.Models
{
    public class PetViewModel : Product
    {
        public int OwnerId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Producto")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un Negocio")]
        public int PetTypeId { get; set; }

        public IEnumerable<SelectListItem> PetTypes { get; set; }
    }
}