using HizliSec.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore.Storage;


namespace HizliSec.Business.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryDal CategoryDal { get; }
        ICustomerDal CustomerDal { get; }
        IOrderDal OrderDal { get; }
        IOrderDetailDal OrderDetailDal { get; }
        IProductDal ProductDal { get; }
        ISellerDal SellerDal { get; }
        ISellerProductDal SellerProductDal { get; }
        IPictureDal PictureDal { get; }
        IMessageDal MessageDal { get; }
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<int> SaveAsync();
    }
}
