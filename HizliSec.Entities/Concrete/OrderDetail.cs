using HizliSec.Core.Entities;
using HizliSec.Entities.Abstract;

namespace HizliSec.Entities.Concrete
{
    public class OrderDetail : BaseEntity, IEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public SellerProduct SellerProduct { get; set; }

    }
}
