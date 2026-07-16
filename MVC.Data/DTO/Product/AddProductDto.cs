namespace MVC.Data.DTO.Product
{
    public class AddProductDto
    {
        public string ProductName { get; set; } = null!;

        public int SupplierId { get; set; }

        public int CategoryId { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }
    }
}
