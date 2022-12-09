using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zoneFlower.Application.Catalog.Products.Dtos;
using zoneFlower.Application.Dtos;
using zoneFlower.Data.EF;
using zoneFlower.Data.Entities;

namespace zoneFlower.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly ZFlowerDbContext _context;
        public ManageProductService(ZFlowerDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
            };
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();

        }

        public Task<int> Delete(int productID)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PagedViewModel<ProductViewModel>> GetAllPaging(string keyword, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(ProductEditRequest request)
        {
            throw new NotImplementedException();
        }
    }
    
}
