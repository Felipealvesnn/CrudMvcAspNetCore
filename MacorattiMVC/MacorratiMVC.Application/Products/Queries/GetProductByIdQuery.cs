using MacorattiMVC.Domain.Entitites;
using MediatR;

namespace MacorratiMVC.Application.Products.Queries
{
    public class GetProductByIdQuery: IRequest<Product>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
