using HizliSec.Core.DataAccess;
using HizliSec.Entities.Concrete;

namespace HizliSec.DataAccess.Abstract
{
    public interface ICategoryDal : IRepositoryBase<Category>
    {
        IQueryable<Category> CategoryWithProducts();
        Task<Category> GetCategoryAsync(int categoryId);
    }
}
