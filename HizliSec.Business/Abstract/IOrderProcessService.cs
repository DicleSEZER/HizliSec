

using HizliSec.Entities.Concrete.Dtos.OrderDtos;

namespace HizliSec.Business.Abstract
{
    public interface IOrderProcessService
    {
        Task<int> AddOrderAsync(OrderAddDto orderAddDto);
    }
}
