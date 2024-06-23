using DOT_NET_CORE_KAFKA.Models;
using MediatR;

namespace DOT_NET_CORE_KAFKA.Commands
{
    public class UpdateProductCommand : IRequest<int>,IProductDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public UpdateProductCommand(int id, string productName, string productDesc, decimal productPrice)
        {
            Id = id;
            Name = productName;
            Description = productDesc;
            Price = productPrice;
        }
    }
}
