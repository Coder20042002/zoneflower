using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zoneFlower.ViewModel.Catalog.Products;
using zoneFlower.ViewModel.Common;

namespace zoneFlower.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        public Task< PagedResult<ProductViewModel>> GetAllByCategory(GetPublicProductPagingRequest request);
        public Task<List<ProductViewModel>> GetAll();
    }
}
