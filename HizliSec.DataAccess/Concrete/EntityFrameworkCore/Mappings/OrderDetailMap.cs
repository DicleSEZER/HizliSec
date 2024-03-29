﻿using HizliSec.Core.DataAccess.EntityFrameworkCore.Mappings;
using HizliSec.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HizliSec.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class OrderDetailMap : EntityMap<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => new { x.OrderId, x.ProductId,x.SellerId});
            builder.Property(x => x.Price).HasColumnType("money");
            base.Configure(builder);
        }
    }
}
