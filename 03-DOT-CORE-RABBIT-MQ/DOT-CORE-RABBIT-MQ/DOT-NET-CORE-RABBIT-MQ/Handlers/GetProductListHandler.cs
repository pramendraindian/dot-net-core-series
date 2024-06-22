using DOT_NET_CORE_RABBIT_MQ.Models;
using DOT_NET_CORE_RABBIT_MQ.Queries;
using DOT_NET_CORE_RABBIT_MQ.Repositories;
using MediatR;
using System.Numerics;

namespace DOT_NET_CORE_RABBIT_MQ.Handlers
{
    public class GetProductListHandler :  IRequestHandler<GetProductListQuery, List<ProductDetails>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductListHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDetails>> Handle(GetProductListQuery query, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductListAsync();
        }
    }
}
