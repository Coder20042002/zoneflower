using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zoneFlower.Application.Dtos;

namespace zoneFlower.Application.Catalog.Products.Dtos.Public
{
    public class GetProductPagingRequest:PagingResultBase
    {
        public int? CategoryId { get; set; }
    }
}
