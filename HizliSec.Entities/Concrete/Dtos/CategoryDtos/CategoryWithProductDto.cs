

namespace HizliSec.Entities.Concrete.Dtos.CategoryDtos
{
    public class CategoryWithProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
