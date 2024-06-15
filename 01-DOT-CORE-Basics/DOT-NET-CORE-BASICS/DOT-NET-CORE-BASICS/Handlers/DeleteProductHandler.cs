using DOT_NET_CORE_BASICS.Commands;
using DOT_NET_CORE_BASICS.Repositories;
using MediatR;

namespace DOT_NET_CORE_BASICS.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var productDetails = await _productRepository.GetProductByIdAsync(command.Id);
            if (productDetails == null)
                return default;

            return await _productRepository.DeleteProductAsync(productDetails.Id);
        }
    }
}