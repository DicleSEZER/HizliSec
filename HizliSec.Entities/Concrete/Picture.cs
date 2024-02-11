using HizliSec.Core.Entities;
using HizliSec.Entities.Abstract;


namespace HizliSec.Entities.Concrete
{
    public class Picture : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public string Image { get; set; }
        public SellerProduct SellerProduct { get; set; }

    }
}
