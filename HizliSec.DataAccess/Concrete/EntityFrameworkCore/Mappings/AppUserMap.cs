using HizliSec.Core.DataAccess.EntityFrameworkCore.Mappings;
using HizliSec.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HizliSec.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class AppUserMap : EntityMap<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {

            builder.HasKey(x=>x.Id);
            builder.HasOne(x => x.Seller).WithOne(x => x.AppUser).HasForeignKey<Seller>(x=>x.Id);
            builder.HasOne(x => x.Customer).WithOne(x => x.AppUser).HasForeignKey<Customer>(x => x.Id);

            base.Configure(builder);
        }
    }
}
