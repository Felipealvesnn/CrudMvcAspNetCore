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
    public class ProductUpdateCommandHandler: IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository??
                throw new ArgumentException(nameof(productRepository));
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.PegaPorId(request.Id);
            if (product == null)
            {
                throw new ApplicationException($"Error de criar entidade");

            }
            else {
                product.Atualizar(request.Name,request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
            
            return await _productRepository.Atualizar(product);
            }

        }
    }
}
