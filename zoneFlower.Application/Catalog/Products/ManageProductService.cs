﻿using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using zoneFlower.Application.Catalog.Common;
using zoneFlower.Data.EF;
using zoneFlower.Data.Entities;
using zoneFlower.Utilities;
using zoneFlower.ViewModel.Catalog.Products;
using zoneFlower.ViewModel.Catalog.Products.Manage;
using zoneFlower.ViewModel.Common;

namespace zoneFlower.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly ZFlowerDbContext _context;
        private readonly IStorageService _storageService;
        public ManageProductService(ZFlowerDbContext context,IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> AddImage(int productID,ProductImageCreateRequest request)
        {
            var productImage = new ProductImage()
            {
                Caption = request.Caption,
                DateCreated = DateTime.Now,
                IsDefault = request.IsDefault,
                ProductId = productID,
                SortOrder=request.SortOrder
            };
            if(request.ImageFile !=null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.ProductImages.Add(productImage);
            await _context.SaveChangesAsync();
            return productImage.Id;
        }

        public async Task AddViewCount(int productId)
        {
            var product=await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated=DateTime.Now,
                ProductTranslations =new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name=request.Name,
                        Description=request.Description,
                        SeoDescription=request.SeoDescription,
                        SeoAlias=request.SeoAlias,
                        SeoTitle=request.SeoTitle,
                        LanguageId=request.LanguageId
                    }
                }
            };
            //Save file 
            if(request.ThumbnailImage !=null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption="Thumbnail image",
                        DateCreated=DateTime.Now,
                        FileSize=request.ThumbnailImage.Length,
                        ImagePath=await this.SaveFile(request.ThumbnailImage),
                        IsDefault=true,
                        SortOrder=1
                    }
                };
            }
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();

        }

        public async Task<int> Delete(int productID)
        {
            var product = await _context.Products.FindAsync(productID);
            if (product == null) throw new ZFlowerException($"Canot find a product :{productID}");

            var Images =  _context.ProductImages.Where(x => x.ProductId == productID);
            foreach(var image in Images)
            {
               await _storageService.DeleteFileAsync(image.ImagePath);
            }
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }


        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            //1.Select join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };
            //2 filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            if(request.CategoryIds.Count>0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
            }
            //3.Paging
            int totalRow = await query.CountAsync();

            var data =await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount

                }).ToListAsync();
                ;


            //4.select add projection
            var pagedResult=new PagedResult<ProductViewModel>()
            {
                TotalRecord=totalRow,
                Items=data
            };
            return pagedResult;

        }

        public Task<List<ProductImageViewModel>> GetListImage(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveImage(int imageId, string caption, bool isDefault)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id);

            if(product == null || productTranslation==null) throw new ZFlowerException($"Canot find a product :{request.Id}");

            productTranslation.Name = request.Name;
            productTranslation.SeoTitle = request.SeoTitle;
            productTranslation.Description = request.Description;
            productTranslation.SeoDescription = request.SeoDescription;
            productTranslation.SeoAlias= request.SeoAlias;
            productTranslation.Details = request.Details;

            //save image
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage =await _context.ProductImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == i.Id);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProductImages.Update(thumbnailImage);
                }
               
                
            }
            return await _context.SaveChangesAsync();

        }

        public Task<int> UpdateImage(int imageId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePrice(int productID, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productID);
            if (product == null) throw new ZFlowerException($"Canot find a product :{productID}");
            product.Price = newPrice;
            return await _context.SaveChangesAsync() >0;

        }

        public async Task<bool> UpdateStock(int productID, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productID);
            if (product == null) throw new ZFlowerException($"Canot find a product :{productID}");
            product.Stock = addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return  fileName;
        }
    }
    
}
