

namespace HizliSec.Entities.Concrete.Dtos.OrderDetailAddDto
{
    public class OrderDetailAddDto
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
