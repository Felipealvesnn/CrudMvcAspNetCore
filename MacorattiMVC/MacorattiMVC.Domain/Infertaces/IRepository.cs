using MacorattiMVC.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacorattiMVC.Domain.Infertaces
{
    public interface IRepository<t> where t:Entity
    {
        Task<IEnumerable<t>> ReTornaTodos();
        Task<t> PegaPorId(int? id);
        Task<t> Adicionar(t entity);
        Task<t> Atualizar(t entity);
        Task<t> Remover(t entity);
    }
}
