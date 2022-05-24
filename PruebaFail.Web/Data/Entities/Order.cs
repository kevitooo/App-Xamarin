using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PruebaFail.Web.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Horario")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Disponible")]
        public bool IsAvailable { get; set; }

        public string Remarks { get; set; }

        public IEnumerable<OrderDetail> Items { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int Lines { get { return Items == null ? 0 : Items.Count(); } }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Quantity { get { return Items == null ? 0 : Items.Sum(i => i.Quantity); } }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Value { get { return Items == null ? 0 : Items.Sum(i => i.Value); } }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:g}")]
        public DateTime DateLocal => Date.ToLocalTime();

        public Owner Owner { get; set; }

        public PetType PetTypes { get; set; }

        public Product Product { get; set; }
    }
}