using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zoneFlower.ViewModel.Catalog.Products;
using zoneFlower.ViewModel.Common;

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

        public Task<int> AddImage(int productID,List<IFormFile> files);
        public Task<int> UpdateImage(int imageId);
        public Task<int> RemoveImage(int imageId,string caption,bool isDefault);

        public Task<List<ProductImageViewModel>> GetListImage(int productId);



    }
}
