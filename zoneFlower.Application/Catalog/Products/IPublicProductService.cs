using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zoneFlower.Application.Catalog.Products.Dtos;
using zoneFlower.Application.Catalog.Products.Dtos.Public;
using zoneFlower.Application.Dtos;

namespace zoneFlower.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        public Task< PagedResult<ProductViewModel>> GetAllByCategory(GetProductPagingRequest request);
    }
}
