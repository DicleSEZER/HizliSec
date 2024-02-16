
namespace HizliSec.Entities.Concrete.Dtos.SellerProductDtos
{
    public class SellerProductDto
    {
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public string ProductName { get; set; }
        public string SellerCompanyName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<string> Pictures { get; set; }
    }
}
