using HizliSec.Business.Abstract;
using HizliSec.Entities.Concrete;
using HizliSec.Entities.Concrete.Dtos.OrderDetailAddDto;


namespace HizliSec.Business.Concrete
{
    public class OrderProcessManager : IOrderProcessService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderProcessManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateOrderAsync(OrderDetailAddDto orderAddDto)
        {
            Customer customer = await _unitOfWork.CustomerDal.GetAsync(x => x.Id == orderAddDto.CustomerId);
            Order order = new Order() { Customer = customer };
            await _unitOfWork.OrderDal.AddAsync(order);
            await _unitOfWork.SaveAsync();
            OrderDetail orderDetail = new OrderDetail
            {
                OrderId = order.Id,
                Price = orderAddDto.Price,
                ProductId = orderAddDto.ProductId,
                SellerId = orderAddDto.SellerId,
                Quantity = orderAddDto.Quantity
            };
            await _unitOfWork.OrderDetailDal.AddAsync(orderDetail);
            Product product = await _unitOfWork.ProductDal.GetAsync(x => x.Id == orderAddDto.ProductId);
            product.UnitInStock -= orderAddDto.Quantity;
            await _unitOfWork.ProductDal.UpdateAsync(product);
            return await _unitOfWork.SaveAsync() > 0;
        }
    }
}
