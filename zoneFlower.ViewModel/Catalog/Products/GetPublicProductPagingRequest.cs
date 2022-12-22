using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zoneFlower.ViewModel.Common;

namespace zoneFlower.ViewModel.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingResultBase
    {
        public string LanguageId { get; set; }
        public int? CategoryId { get; set; }
    }
}
