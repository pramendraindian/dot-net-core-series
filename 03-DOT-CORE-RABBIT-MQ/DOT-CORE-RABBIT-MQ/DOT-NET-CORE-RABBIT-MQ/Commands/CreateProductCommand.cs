using DOT_NET_CORE_RABBIT_MQ.Models;
using MediatR;
using System.Numerics;

namespace DOT_NET_CORE_RABBIT_MQ.Commands
{
    public class CreateProductCommand : IRequest<ProductDetails>,IProductDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public CreateProductCommand(string productName, string productDesc, decimal productPrice)
        {
            Name = productName;
            Description = productDesc;
            Price = productPrice;
        }
    }
}
