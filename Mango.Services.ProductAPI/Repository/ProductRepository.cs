﻿using AutoMapper;
using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository// implement the IProductRepository
    {

        private readonly ApplicationDbContext _db;// using dependency injection 
        private IMapper _mapper;

        public  ProductRepository(ApplicationDbContext db,IMapper mapper) //using dependency injection
        {
            db = _db;
            mapper = _mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            if (product.ProductId > 0)
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
            
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
                if (product == null)
                {
                    return false;
                }
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
              Product product = await _db.Products.Where(p=>p.ProductId== productId).FirstOrDefaultAsync();
              return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
          List<Product> productList= await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }
    }
}
