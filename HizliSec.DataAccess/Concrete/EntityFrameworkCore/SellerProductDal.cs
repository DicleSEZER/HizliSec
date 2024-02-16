using HizliSec.Core.DataAccess.EntityFrameworkCore;
using HizliSec.DataAccess.Abstract;
using HizliSec.DataAccess.Concrete.EntityFrameworkCore.Context;
using HizliSec.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using HizliSec.Core.DataAccess.EntityFrameworkCore;
using HizliSec.DataAccess.Abstract;
using HizliSec.DataAccess.Concrete.EntityFrameworkCore.Context;
using HizliSec.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HizliSec.DataAccess.Concrete.EntityFrameworkCore
{
    public class SellerProductDal : RepositoryBase<SellerProduct>, ISellerProductDal
    {
        public SellerProductDal(HizliSecContext context) : base(context)
        {

        }

        public IQueryable<SellerProduct> SellerProductWithCategoryAndPictures(Expression<Func<SellerProduct, bool>> expression) => expression is not null ?
            _set.Where(expression).Include(x => x.Pictures).Include(x => x.Seller).ThenInclude(x => x.AppUser).Include(p => p.Product).ThenInclude(c => c.Category) : _set.Include(x => x.Pictures).Include(x => x.Seller).ThenInclude(x => x.AppUser).Include(p => p.Product).ThenInclude(c => c.Category);


    }
}
