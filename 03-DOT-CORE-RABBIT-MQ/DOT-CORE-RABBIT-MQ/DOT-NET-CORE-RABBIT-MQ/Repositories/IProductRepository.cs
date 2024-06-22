using DOT_NET_CORE_RABBIT_MQ.Models;

namespace DOT_NET_CORE_RABBIT_MQ.Repositories
{
    public interface IProductRepository
    {
        public Task<List<ProductDetails>> GetProductListAsync();
        public Task<ProductDetails> GetProductByIdAsync(int Id);
        public Task<ProductDetails> AddProductAsync(ProductDetails productDetails);
        public Task<int> UpdateProductAsync(ProductDetails productDetails);
        public Task<int> DeleteProductAsync(int Id);
    }
}
