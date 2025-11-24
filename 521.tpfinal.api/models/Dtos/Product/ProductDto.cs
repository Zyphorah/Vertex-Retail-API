namespace _521.tpfinal.api.models.Dtos.Product
{
    public class ProductDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required string Category { get; set; }
        public required int Stock { get; set; }
    }
}