using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoneFlower.Data.Entities
{
    public class Product
    {
        public int Id { set; get; }
        public decimal Price { set; get; }
        public int OriginalPrice { set; get; }
        public decimal Stock { set; get; }
        public int ViewCount { set; get; }
        public DateTime DateCreate { set; get; }
        public string SeoAlias { set; get; }
    }
}
