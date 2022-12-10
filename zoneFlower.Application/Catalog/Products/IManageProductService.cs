using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zoneFlower.Application.Catalog.Products.Dtos;
using zoneFlower.Application.Catalog.Products.Dtos.Manage;
using zoneFlower.Application.Dtos;

namespace zoneFlower.Application.Catalog.Products
{
    public interface IManageProductService
    {
        
        public Task<int> Create(ProductCreateRequest request);
        public Task<int> Update(ProductUpdateRequest request);
        public Task<int> Delete(int productID);
        public Task<bool> UpdatePrice(int productID,decimal newPrice);
        public Task<bool> UpdateStock(int productID,int addedQuantity);
        public Task AddViewCount(int productId);
        public Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
    }
}
