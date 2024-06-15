using DOT_NET_CORE_BASICS.Models;
using MediatR;

namespace DOT_NET_CORE_BASICS.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDetails>
    {
        public int Id { get; set; }
    }
}
