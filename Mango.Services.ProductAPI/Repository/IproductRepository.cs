using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Repository
{
     public  interface IProductRepository
     {
        Task<IEnumerable<ProductDto>> GetProducts();// for async method that returns a value get all product
        Task<ProductDto> GetProductById(int productId);// get product by Id
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);//update product
        Task<bool> DeleteProduct(int productId);// delete product
     }
}
