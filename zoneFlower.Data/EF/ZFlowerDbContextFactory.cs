using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zoneFlower.Data;


namespace zoneFlower.Data.EF
{
    public class ZFlowerDbContextFactory : IDesignTimeDbContextFactory<ZFlowerDbContext>
    {
        public ZFlowerDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("zoneFlowerDb");

            var optionsBuilder = new DbContextOptionsBuilder<ZFlowerDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ZFlowerDbContext(optionsBuilder.Options);
        }
    }
}
