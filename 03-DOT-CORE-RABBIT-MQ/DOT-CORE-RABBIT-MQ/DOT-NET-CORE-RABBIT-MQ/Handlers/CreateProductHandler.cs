using DOT_NET_CORE_RABBIT_MQ.Commands;
using DOT_NET_CORE_RABBIT_MQ.Models;
using DOT_NET_CORE_RABBIT_MQ.Repositories;
using MediatR;
using System.Numerics;

namespace DOT_NET_CORE_RABBIT_MQ.Handlers
{
    public class CreateProductHandler: IRequestHandler<CreateProductCommand, ProductDetails>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDetails> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var productDetails = new ProductDetails()
            {
                Name = command.Name,
                Description = command.Description,
                Price= command.Price
                            };

            return await _productRepository.AddProductAsync(productDetails);
        }
    }
}
