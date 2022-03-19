using AutoMapper;
using MacorattiMVC.Domain.Entitites;
using MacorattiMVC.Domain.Infertaces;
using MacorratiMVC.Application.DTOs;
using MacorratiMVC.Application.Interfaces;
using MacorratiMVC.Application.Products.Commands;
using MacorratiMVC.Application.Products.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MacorratiMVC.Application.Services
{
    public class ProductService : IProductService
    {   
        
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            
            _mapper = mapper;

        }
        public async Task<IEnumerable<ProductDTO>> RetornaTodos()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }
        public async Task<ProductDTO> PegarPorId(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }
        //public async Task<ProductDTO> PegarProCategoryId(int? id)
        //{
        //    var productByIdQuery = new GetProductByIdQuery(id.Value);

        //    if (productByIdQuery == null)
        //        throw new Exception($"Entity could not be loaded.");

        //    var result = await _mediator.Send(productByIdQuery);

        //    return _mapper.Map<ProductDTO>(result);
        //}

        public async Task Add(ProductDTO productDTO)
        {

            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }


        public async Task Remove(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);
            if (productRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(productRemoveCommand);
        }

        

        public async Task Update(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }
    }
}
