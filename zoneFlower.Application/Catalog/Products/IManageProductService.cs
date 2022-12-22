using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zoneFlower.ViewModel.Catalog.Products;
using zoneFlower.ViewModel.Common;
using zoneFlower.ViewModel.ProductImages;

namespace zoneFlower.Application.Catalog.Products
{
    public interface IManageProductService
    {
        
        public Task<int> Create(ProductCreateRequest request);
        public Task<int> Update(ProductUpdateRequest request);
        public Task<int> Delete(int productID);
        public Task<ProductViewModel>GetById(int productID,string langugeId);
        public Task<bool> UpdatePrice(int productID,decimal newPrice);
        public Task<bool> UpdateStock(int productID,int addedQuantity);
        public Task AddViewCount(int productId);
        public Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        public Task<int> AddImage(int productID,ProductImageCreateRequest request);
        public Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);
        public Task<int> RemoveImage(int imageId);
        public Task<ProductImageViewModel> GetImageById(int imageId);
        public Task<List<ProductImageViewModel>> GetListImage(int productId);



    }
}
