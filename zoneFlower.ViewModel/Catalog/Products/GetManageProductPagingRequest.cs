using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zoneFlower.ViewModel.Common;

namespace zoneFlower.ViewModel.Catalog.Products
{
    public class GetManageProductPagingRequest: PagingResultBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
