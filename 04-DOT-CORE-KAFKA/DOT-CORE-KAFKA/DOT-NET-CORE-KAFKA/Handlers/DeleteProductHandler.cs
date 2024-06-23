using DOT_NET_CORE_KAFKA.Commands;
using DOT_NET_CORE_KAFKA.Repositories;
using MediatR;

namespace DOT_NET_CORE_KAFKA.Handlers
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