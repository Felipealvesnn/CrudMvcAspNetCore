using MacorattiMVC.Domain.Entitites;
using MacorattiMVC.Domain.Infertaces;
using MacorratiMVC.Application.Products.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MacorratiMVC.Application.Products.Handlers
{
    public class PegarTodosOsprodutosHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;
        public PegarTodosOsprodutosHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ??
                throw new ArgumentException(nameof(productRepository));
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.ReTornaTodos();
        }
    }
}
