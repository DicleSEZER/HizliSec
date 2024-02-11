using HizliSec.Core.Entities;
using HizliSec.Entities.Abstract;

namespace HizliSec.Entities.Concrete
{
    public class Seller :BaseEntity, IEntity
    {
        public Seller() => SellerProducts = new List<SellerProduct>();
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<SellerProduct> SellerProducts { get; set; }

       
    }
}
