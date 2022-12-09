using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zoneFlower.Application.Catalog.Products.Dtos;
using zoneFlower.Application.Dtos;

namespace zoneFlower.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        public PagedViewModel<ProductViewModel> GetAllByCategory(int categoryId,int pageIndex,int pageSize);
    }
}
