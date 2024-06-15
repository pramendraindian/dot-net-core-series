using DOT_NET_CORE_BASICS.Commands;
using DOT_NET_CORE_BASICS.Models;
using DOT_NET_CORE_BASICS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DOT_NET_CORE_BASICS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
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

        [HttpPost]
        public async Task<ProductDetails> AddProductAsync(ProductDetails productDetails)
        {
            var productDetail = await mediator.Send(new CreateProductCommand(
                productDetails.Name,productDetails.Description, productDetails.Price));
            return productDetail;
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