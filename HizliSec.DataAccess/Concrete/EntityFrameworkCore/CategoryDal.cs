using HizliSec.Core.DataAccess.EntityFrameworkCore;
using HizliSec.DataAccess.Abstract;
using HizliSec.DataAccess.Concrete.EntityFrameworkCore.Context;
using HizliSec.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HizliSec.DataAccess.Concrete.EntityFrameworkCore
{
    public class CategoryDal : RepositoryBase<Category>, ICategoryDal
    {
        public CategoryDal(HizliSecContext context) : base(context)
        {

        }

        public IQueryable<Category> CategoryWithProducts() => _set.Include(x => x.Products);

        public async Task<Category> GetCategoryAsync(int categoryId) => await _set.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == categoryId);
    }
}
