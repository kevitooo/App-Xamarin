namespace PruebaFail.Web.Data.Entities
{
    public class ServiceType
    {
        public int Id { get; set; }

        public User User { get; set; }

        public PetType PetType { get; set; }
    }
}