using Autofac;
using HizliSec.Business.Abstract;
using HizliSec.Business.Concrete;


namespace HizliSec.Business.DependencyResolvers.AutoFac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<MessageManager>().As<IMessageService>();
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<SellerProductManager>().As<ISellerProductService>();
            builder.RegisterType<OrderProcessManager>().As<IOrderProcessService>();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            base.Load(builder);
        }
    }
}
