using HizliSec.Core.Entities;
using HizliSec.Entities.Abstract;

namespace HizliSec.Entities.Concrete
{
    public class Category : BaseEntity, IEntity
    {
        public Category() => Products = new List<Product>();

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; }
        public ICollection<Product> Products { get; set; }
      
    }
}
