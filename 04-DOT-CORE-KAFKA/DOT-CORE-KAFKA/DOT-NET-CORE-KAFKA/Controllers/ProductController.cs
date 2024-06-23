using DOT_NET_CORE_KAFKA.Commands;
using DOT_NET_CORE_KAFKA.Models;
using DOT_NET_CORE_KAFKA.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DOT_NET_CORE_KAFKA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMessageProducer kafkaProducer;
        public ProductController(IMediator mediator, IMessageProducer kafkaProducer)
        {
            this.mediator = mediator;
            this.kafkaProducer = kafkaProducer;
        }

        [HttpPost]
        public async Task<ProductDetails> AddProductAsync(ProductDetails productDetails)
        {
            var productDetail = await mediator.Send(new CreateProductCommand(
            productDetails.Name, productDetails.Description, productDetails.Price));
            this.kafkaProducer.SendMessage("product-topic", $"Product#{Convert.ToString(productDetail.Id)}",productDetail);
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