using HizliSec.Core.Entities;
using HizliSec.Entities.Abstract;

namespace HizliSec.Entities.Concrete
{
    public class Product : BaseEntity, IEntity
    {
        public Product() => SellerProducts = new List<SellerProduct>();
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public ICollection<SellerProduct> SellerProducts { get; set; }
    }
}
