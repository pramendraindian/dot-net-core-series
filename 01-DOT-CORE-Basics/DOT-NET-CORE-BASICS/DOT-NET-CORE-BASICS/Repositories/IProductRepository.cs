using DOT_NET_CORE_BASICS.Models;

namespace DOT_NET_CORE_BASICS.Repositories
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
