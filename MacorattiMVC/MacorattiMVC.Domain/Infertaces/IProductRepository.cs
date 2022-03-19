using MacorattiMVC.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacorattiMVC.Domain.Infertaces
{
    public interface IProductRepository: IRepository<Product>
    {
        
       // Task<Product> PegaPorIdCategoria(int? id);
        
    }
}
