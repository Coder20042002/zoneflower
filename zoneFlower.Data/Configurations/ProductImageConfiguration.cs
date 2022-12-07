using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zoneFlower.Data.Entities;

namespace zoneFlower.Data.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.ToTable("ProductImages");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.ImagePath).HasMaxLength(200).IsRequired(true);
        builder.Property(x => x.Caption).HasMaxLength(200);

        builder.HasOne(x => x.Product).WithMany(x => x.ProductImages).HasForeignKey(x => x.ProductId);
    }
}
}
