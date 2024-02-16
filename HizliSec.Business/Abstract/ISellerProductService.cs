using HizliSec.Entities.Concrete.Dtos.SellerProductDtos;

namespace HizliSec.Business.Abstract
{
    public interface ISellerProductService
    {
        Task<int> AddAsyn(SellerProductAddDto productAddDto);
        List<SellerProductDto> GetProductsBySellerId(int sellerId);
        List<SellerProductDto> GetAllSellerAndProducts();
    }
}
