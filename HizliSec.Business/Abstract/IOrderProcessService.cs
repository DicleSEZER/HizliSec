

using HizliSec.Entities.Concrete.Dtos.OrderDetailAddDto;
using HizliSec.Entities.Concrete.Dtos.OrderDtos;

namespace HizliSec.Business.Abstract
{
    public interface IOrderProcessService
    {
        Task<bool> CreateOrderAsync(OrderDetailAddDto orderAddDto);
    }
}
