namespace PruebaFail.Common.Models
{
    public class PetResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        public double Stock { get; set; }

        public string PetType { get; set; }
    }
}