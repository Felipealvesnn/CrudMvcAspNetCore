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
    public class ProductRepository : IProductRepository
    {
        private readonly BancoContexto _categoryContext;
        public ProductRepository(BancoContexto context)
        {
            _categoryContext = context;
        }

        public async Task<Product> Adicionar(Product entity)
        {
            _categoryContext.Add(entity);
            await _categoryContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Product> Atualizar(Product entity)
        {
            _categoryContext.Update(entity);
            await _categoryContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Product> PegaPorId(int? id)
        {
            // return await _categoryContext.Produtos.FindAsync(id);
            return await _categoryContext.Produtos.Include(c => c.Category)
               .SingleOrDefaultAsync(p => p.Id == id);

        }

        //public async Task<Product> PegaPorIdCategoria(int? id)
        //{
        //    return await _categoryContext.Produtos.Include(c => c.Category)
        //        .SingleOrDefaultAsync(p => p.Id == id);
        //}

        public async Task<Product> Remover(Product entity)
        {
            _categoryContext.Remove(entity);
            await _categoryContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Product>> ReTornaTodos()
        {
            return await _categoryContext.Produtos.ToListAsync();
        }
    }
}
