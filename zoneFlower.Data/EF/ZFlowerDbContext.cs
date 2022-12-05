using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zoneFlower.Data.Entities;

namespace zoneFlower.Data.EF
{
    public class ZFlowerDbContext : DbContext
    {
        public ZFlowerDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
