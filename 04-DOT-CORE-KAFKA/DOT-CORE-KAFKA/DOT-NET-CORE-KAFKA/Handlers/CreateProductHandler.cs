﻿using DOT_NET_CORE_KAFKA.Commands;
using DOT_NET_CORE_KAFKA.Models;
using DOT_NET_CORE_KAFKA.Repositories;
using MediatR;
using System.Numerics;

namespace DOT_NET_CORE_KAFKA.Handlers
{
    public class CreateProductHandler: IRequestHandler<CreateProductCommand, ProductDetails>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDetails> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var productDetails = new ProductDetails()
            {
                Name = command.Name,
                Description = command.Description,
                Price= command.Price
                            };

            return await _productRepository.AddProductAsync(productDetails);
        }
    }
}
