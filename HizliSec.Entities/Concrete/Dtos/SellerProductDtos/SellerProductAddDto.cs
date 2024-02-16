

using Microsoft.AspNetCore.Http;

namespace HizliSec.Entities.Concrete.Dtos.SellerProductDtos
{
    public class SellerProductAddDto
    {
        public SellerProductAddDto()
        {
            Pictures = new();
        }
        public string SellerUserName { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Product Product { get; set; }
        public List<IFormFile> Pictures { get; set; }
    }
}
