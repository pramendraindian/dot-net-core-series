using MediatR;

namespace DOT_NET_CORE_RABBIT_MQ.Commands
{
    public class DeleteProductCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}

