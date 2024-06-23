using DOT_NET_CORE_KAFKA.Models;
using MediatR;

namespace DOT_NET_CORE_KAFKA.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDetails>
    {
        public int Id { get; set; }
    }
}
