using HizliSec.Entities.Concrete.Dtos.ProductDtos;


namespace HizliSec.Business.Abstract
{
    public interface IProductService
    {
        Task<ProductDto> GetByIdAsync(int id);
        Task<List<ProductDto>> GetAllAsync();
        Task<int> AddAsync(ProductAddDto productAddDto);
    }
}
