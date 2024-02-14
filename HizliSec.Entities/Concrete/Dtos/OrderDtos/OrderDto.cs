

using HizliSec.Core.Entities;

namespace HizliSec.Entities.Concrete.Dtos.OrderDtos
{
    public class OrderDto : IDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
