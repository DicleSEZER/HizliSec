using HizliSec.Core.Entities;
using HizliSec.Entities.Abstract;

namespace HizliSec.Entities.Concrete
{
    public class SellerProduct : BaseEntity, IEntity
    {
        public SellerProduct()
        {
            OrderDetails = new List<OrderDetail>();
            Pictures = new List<Picture>();
        }
        public int SellerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Seller Seller { get; set; }
        public Product Product { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Picture> Pictures { get; set; }
    }
}
