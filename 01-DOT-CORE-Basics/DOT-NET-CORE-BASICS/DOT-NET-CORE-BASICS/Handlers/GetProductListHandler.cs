using DOT_NET_CORE_BASICS.Models;
using DOT_NET_CORE_BASICS.Queries;
using DOT_NET_CORE_BASICS.Repositories;
using MediatR;
using System.Numerics;

namespace DOT_NET_CORE_BASICS.Handlers
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
