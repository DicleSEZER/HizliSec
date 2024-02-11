using HizliSec.Core.Entities;
using HizliSec.Entities.Abstract;

namespace HizliSec.Entities.Concrete
{
    public class Customer : BaseEntity, IEntity
    {
        public Customer() => Orders = new List<Order>();
        public int Id { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
