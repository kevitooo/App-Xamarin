using System.Collections.Generic;

namespace PruebaFail.Web.Data.Entities
{
    public class PetType
    {
        public int Id { get; set; }

        public User User { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<ServiceType> serviceTypes { get; set; }

        public ICollection<PetType> petTypes { get; set; }
    }
}