using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zoneFlower.ViewModel.Common;

namespace zoneFlower.ViewModel.Catalog.Products.Public
{
    public class GetProductPagingRequest : PagingResultBase
    {
        public int? CategoryId { get; set; }
    }
}
