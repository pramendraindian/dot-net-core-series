using MediatR;

namespace DOT_NET_CORE_BASICS.Commands
{
    public class DeleteProductCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}

