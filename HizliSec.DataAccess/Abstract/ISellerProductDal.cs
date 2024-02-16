using HizliSec.Core.DataAccess;
using HizliSec.Entities.Concrete;
using System.Linq.Expressions;

namespace HizliSec.DataAccess.Abstract
{
    public interface ISellerProductDal : IRepositoryBase<SellerProduct>
    {
        IQueryable<SellerProduct> SellerProductWithCategoryAndPictures(Expression<Func<SellerProduct, bool>> expression = null);
    }
}
