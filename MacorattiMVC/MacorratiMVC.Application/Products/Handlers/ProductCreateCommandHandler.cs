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
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository=productRepository;
        }

        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description,request.Price, request.Stock,request.Image);
            if (product == null) {
                throw new ApplicationException($"Error de criar entidade");
           }

            else
            {
                product.CategoryId = request.CategoryId;
                return await _productRepository.Adicionar(product);
            }
        }
    }
}
