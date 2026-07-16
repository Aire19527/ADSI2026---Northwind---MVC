namespace MVC.Data.DTO.Product
{
    public class ProductDto : UpdateProductDto
    {
        public string Supplier { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;
    }
}
