using DOT_NET_CORE_RABBIT_MQ.Models;
using DOT_NET_CORE_RABBIT_MQ.Queries;
using DOT_NET_CORE_RABBIT_MQ.Repositories;
using MediatR;
using System.Numerics;

namespace DOT_NET_CORE_RABBIT_MQ.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDetails>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDetails> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductByIdAsync(query.Id);
        }
    }
}
