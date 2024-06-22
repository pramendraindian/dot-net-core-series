using DOT_NET_CORE_RABBIT_MQ.Models;
using MediatR;

namespace DOT_NET_CORE_RABBIT_MQ.Queries
{
    public class GetProductListQuery :  IRequest<List<ProductDetails>>
    {
    }
}
