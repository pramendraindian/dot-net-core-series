﻿using DOT_NET_CORE_RABBIT_MQ.Data;
using DOT_NET_CORE_RABBIT_MQ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Numerics;

namespace DOT_NET_CORE_RABBIT_MQ.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EFDbContext _dbContext;

        public ProductRepository(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductDetails> AddProductAsync(ProductDetails productDetails)
        {
            var result = _dbContext.Products.Add(productDetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteProductAsync(int Id)
        {
            var filteredData = _dbContext.Products.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Products.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<ProductDetails> GetProductByIdAsync(int Id)
        {
            return await _dbContext.Products.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<ProductDetails>> GetProductListAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<int> UpdateProductAsync(ProductDetails productDetails)
        {
            _dbContext.Products.Update(productDetails);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
