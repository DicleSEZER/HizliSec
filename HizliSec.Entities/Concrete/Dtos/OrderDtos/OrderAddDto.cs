

using HizliSec.Core.Entities;

namespace HizliSec.Entities.Concrete.Dtos.OrderDtos
{
    public class OrderAddDto : IDto
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
