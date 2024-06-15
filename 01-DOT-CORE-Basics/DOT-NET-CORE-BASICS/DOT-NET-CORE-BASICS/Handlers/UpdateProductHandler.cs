﻿using DOT_NET_CORE_BASICS.Commands;
using DOT_NET_CORE_BASICS.Repositories;
using MediatR;

namespace DOT_NET_CORE_BASICS.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var productDetails = await _productRepository.GetProductByIdAsync(command.Id);
            if (productDetails == null)
                return default;

            productDetails.Name = command.Name;
            productDetails.Description = command.Description;
            productDetails.Price = command.Price;

            return await _productRepository.UpdateProductAsync(productDetails);
        }
    }
}
