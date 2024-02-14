using HizliSec.Core.Entities;

namespace HizliSec.Entities.Concrete.Dtos.ProductDtos
{
    public class ProductDto : IDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
