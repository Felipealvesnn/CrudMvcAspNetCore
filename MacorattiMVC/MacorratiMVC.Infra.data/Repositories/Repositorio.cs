using MacorattiMVC.Domain.Entitites;
using MacorattiMVC.Domain.Infertaces;
using MacorratiMVC.Infra.data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacorratiMVC.Infra.data.Repositories
{
    public class Repositorio<t> : IRepository<t> where t : Entity
    {
        private readonly BancoContexto _categoryContext;
        public Repositorio(BancoContexto context)
        {
            _categoryContext = context;
        }
        public async  Task<t> Adicionar(t entity)
         {
            _categoryContext.Set<t>().Add(entity);
            await _categoryContext.SaveChangesAsync();
            return entity;
            

        }

        public async Task<t> Atualizar(t entity)
        {
          
            _categoryContext.Update(entity);
            await _categoryContext.SaveChangesAsync();
            return entity;
        }

        public async Task<t> PegaPorId(int? id)
        {
            return await _categoryContext.Set<t>().FindAsync(id);
        }

        public async Task<t> Remover(t entity)
        {
             _categoryContext.Set<t>().Remove(entity);
            await _categoryContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<t>> ReTornaTodos()
        {
            return await _categoryContext.Set<t>().ToListAsync();
        }

      
    }
}
