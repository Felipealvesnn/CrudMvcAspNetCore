using MacorattiMVC.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacorratiMVC.Application.Products.Queries
{
    public   class GetProductsQuery: IRequest<IEnumerable<Product>>
    {
    }
}
