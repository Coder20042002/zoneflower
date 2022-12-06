using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zoneFlower.Data.Entities;

namespace zoneFlower.Data.Configurations
{
    //kết nối và tạo bảng bằng entity(Fuent API)
    public class AppConfigConfiguration : IEntityTypeConfiguration<AppConfig>
    {
        public void Configure(EntityTypeBuilder<AppConfig> builder)
        {
            //tạo tên bảng
            builder.ToTable("AppConfigs");
            //tạo khoá
            builder.HasKey(x => x.Key);
            //tạo thuộc tính
            builder.Property(x => x.Value).IsRequired(true);
        }
    }
}
