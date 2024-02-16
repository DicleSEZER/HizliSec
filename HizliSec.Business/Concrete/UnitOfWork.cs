using HizliSec.Business.Abstract;
using HizliSec.DataAccess.Abstract;
using HizliSec.DataAccess.Concrete.EntityFrameworkCore.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace HizliSec.Business.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryDal CategoryDal { get; }
        public ICustomerDal CustomerDal { get; }
        public IOrderDal OrderDal { get; }
        public IOrderDetailDal OrderDetailDal { get; }
        public IProductDal ProductDal { get; }
        public ISellerDal SellerDal { get; }
        public ISellerProductDal SellerProductDal { get; }
        public IPictureDal PictureDal { get; }

        public IMessageDal MessageDal { get; }

        HizliSecContext _context;

        public UnitOfWork(ICategoryDal categoryDal, ICustomerDal customerDal, IOrderDal orderDal, IOrderDetailDal orderDetailDal, IProductDal productDal, ISellerDal sellerDal, ISellerProductDal sellerProductDal, IPictureDal pictureDal, IMessageDal messageDal, HizliSecContext context)
        {
            CategoryDal = categoryDal;
            CustomerDal = customerDal;
            OrderDal = orderDal;
            OrderDetailDal = orderDetailDal;
            ProductDal = productDal;
            SellerDal = sellerDal;
            SellerProductDal = sellerProductDal;
            PictureDal = pictureDal;
            MessageDal = messageDal;
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync().Result;
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }
    }
}
