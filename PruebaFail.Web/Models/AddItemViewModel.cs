using Microsoft.AspNetCore.Mvc.Rendering;
using PruebaFail.Web.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaFail.Web.Models
{
    public class AddItemViewModel : Product
    {
        [Display(Name = "Producto")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un producto.")]
        public int ProductId { get; set; }

        [Range(0.0001, double.MaxValue, ErrorMessage = "La cantidad debe ser un numero positivo.")]
        public double Quantity { get; set; }

        public IEnumerable<SelectListItem> Products { get; set; }
    }
}