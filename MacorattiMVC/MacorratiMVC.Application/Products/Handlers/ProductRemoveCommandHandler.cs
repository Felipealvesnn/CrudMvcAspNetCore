using MacorattiMVC.Domain.Entitites;
using MacorattiMVC.Domain.Infertaces;
using MacorratiMVC.Application.Products.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MacorratiMVC.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ??
                throw new ArgumentException(nameof(productRepository));
        }

        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var producto = await _productRepository.PegaPorId(request.Id);
            if (producto == null)
            {
                throw new ApplicationException($"Error de criar entidade");

            }
            else
            {
                

                return await _productRepository.Remover(producto);
            }
            
        }
    }
}
