

using HizliSec.Entities.Concrete.Dtos.CategoryDtos;

namespace HizliSec.Business.Abstract
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetCategory(int id);
        Task<List<CategoryDto>> GetAllCategories();
        List<CategoryWithProductDto> CategoryWithProducts();
        Task<CategoryWithProductDto> CategoryWithProduct(int categoryId);
        Task<int> Add(CategoryAddDto categoryAddDto);
        Task<int> Remove(int id);
        Task<int> Uptade(CategoryDto categoryDto);
    }
}
