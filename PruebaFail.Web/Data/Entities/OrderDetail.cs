using System.ComponentModel.DataAnnotations;

namespace PruebaFail.Web.Data.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }

        [Required]
        public Product Product { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:D}")]
        public double Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Value { get { return Price * (decimal)Quantity; } }
    }
}