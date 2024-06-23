using DOT_NET_CORE_KAFKA.Models;
using MediatR;

namespace DOT_NET_CORE_KAFKA.Queries
{
    public class GetProductListQuery :  IRequest<List<ProductDetails>>
    {
    }
}
