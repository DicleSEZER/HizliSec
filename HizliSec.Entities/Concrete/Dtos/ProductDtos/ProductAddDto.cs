

using HizliSec.Core.Entities;

namespace HizliSec.Entities.Concrete.Dtos.ProductDtos
{
    public class ProductAddDto : IDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
