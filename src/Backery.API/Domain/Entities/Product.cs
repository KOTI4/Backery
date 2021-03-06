namespace Supermarket.API.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short TimeFromBacking { get; set; }
        public short Weight { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}