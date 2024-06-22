using DOT_NET_CORE_RABBIT_MQ.Commands;
using DOT_NET_CORE_RABBIT_MQ.Models;
using DOT_NET_CORE_RABBIT_MQ.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DOT_NET_CORE_RABBIT_MQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMessageProducer rabitMQProducer;
        public ProductController(IMediator mediator, IMessageProducer rabitMQProducer)
        {
            this.mediator = mediator;
            this.rabitMQProducer = rabitMQProducer;
        }

        [HttpPost]
        public async Task<ProductDetails> AddProductAsync(ProductDetails productDetails)
        {
            var productDetail = await mediator.Send(new CreateProductCommand(
                productDetails.Name, productDetails.Description, productDetails.Price));
            this.rabitMQProducer.SendMessageToQueue(productDetail);
            return productDetail;
        }

        [HttpGet]
        public async Task<List<ProductDetails>> GetProductListAsync()
        {
            var productDetails = await mediator.Send(new GetProductListQuery());

            return productDetails;
        }

        [HttpGet("productId")]
        public async Task<ProductDetails> GetProductByIdAsync(int prodcuctId)
        {
            var productDetails = await mediator.Send(new GetProductByIdQuery() { Id = prodcuctId });

            return productDetails;
        }

        

        [HttpPut]
        public async Task<int> UpdateProductAsync(ProductDetails productDetails)
        {
            var isProductDetailUpdated = await mediator.Send(new UpdateProductCommand(
               productDetails.Id,
               productDetails.Name, productDetails.Description, productDetails.Price));
            return isProductDetailUpdated;
        }

        [HttpDelete]
        public async Task<int> DeleteProductAsync(int Id)
        {
            return await mediator.Send(new DeleteProductCommand() { Id = Id });
        }
    }
}