using MacorattiMVC.Domain.Entitites;
using MacorattiMVC.Domain.Infertaces;
using MacorratiMVC.Infra.data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacorratiMVC.Infra.data.Repositories
{
    public class CategoryRepository : Repositorio<Category>, ICategoryRepository
    {
        public CategoryRepository(BancoContexto context) : base(context)
        {
        }
    }
}
