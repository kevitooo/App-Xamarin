using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaFail.Web.Models
{
    public class DeliverViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Fecha de entrega")]
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; }
    }
}