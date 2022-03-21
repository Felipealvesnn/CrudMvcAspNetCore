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
    internal class CategoryRepositoryNaMao : ICategoryRepository
    {
        private readonly BancoContexto _categoryContext;
        public CategoryRepositoryNaMao(BancoContexto context)
        {
            _categoryContext = context;
        }
        public async Task<Category> Adicionar(Category entity)
        {
            _categoryContext.Add(entity);
            await _categoryContext.SaveChangesAsync();
            
            return entity;
        }

        public async Task<Category> Atualizar(Category entity)
        {
            _categoryContext.Update(entity);
            await _categoryContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Category> PegaPorId(int? id)
        {
            return await _categoryContext.Categorias.FindAsync(id);
        }

        public async Task<Category> Remover(Category entity)
        {
            _categoryContext.Remove(entity);
            await saveAsync();
            return entity;
        }

        public async Task<IEnumerable<Category>> ReTornaTodos()
        {
            return await _categoryContext.Categorias.ToListAsync();
        }

        private async Task saveAsync()
        {
           await _categoryContext.SaveChangesAsync();

        }
    }
}
