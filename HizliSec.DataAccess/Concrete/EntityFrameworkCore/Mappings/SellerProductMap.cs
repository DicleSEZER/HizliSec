using HizliSec.Core.DataAccess.EntityFrameworkCore.Mappings;
using HizliSec.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HizliSec.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class SellerProductMap : EntityMap<SellerProduct>
    {
        public override void Configure(EntityTypeBuilder<SellerProduct> builder)
        {
            builder.HasKey(x => new {x.SellerId, x.ProductId });
            builder.Property(x => x.Price).HasColumnType("money");
            builder.HasMany(x => x.OrderDetails).WithOne(x => x.SellerProduct).HasForeignKey(x=> new {x.ProductId,x.SellerId}).OnDelete( DeleteBehavior.NoAction) ;
            builder.HasMany(x => x.Pictures).WithOne(x => x.SellerProduct).HasForeignKey(x => new { x.ProductId, x.SellerId });
            base.Configure(builder);
        }
    }
}
