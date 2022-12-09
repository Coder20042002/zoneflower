using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zoneFlower.Application.Catalog.Products.Dtos;
using zoneFlower.Application.Dtos;

namespace zoneFlower.Application.Catalog.Products
{
    public interface IManageProductService
    {
        
        public Task<int> Create(ProductCreateRequest request);
        public Task<int> Update(ProductEditRequest request);
        public Task<int> Delete(int productID);
        public Task<List<ProductViewModel>> GetAll();
        public Task<PagedViewModel<ProductViewModel>> GetAllPaging(string keyword,int pageIndex,int pageSize);
    }
}
