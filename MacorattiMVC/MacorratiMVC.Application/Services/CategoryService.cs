using AutoMapper;
using MacorattiMVC.Domain.Entitites;
using MacorattiMVC.Domain.Infertaces;
using MacorratiMVC.Application.DTOs;
using MacorratiMVC.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MacorratiMVC.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categorypository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categorypository = categoryRepository;
            _mapper = mapper;

        }
        public async Task Add(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categorypository.Adicionar(categoryEntity);
        }
        public async Task Update(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categorypository.Atualizar(categoryEntity);

        }
        public async Task Remove(int? id)
        {
            var categoryEntity = _categorypository.PegaPorId(id).Result;
            await _categorypository.Remover(categoryEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> RetornaTodos()
        {
            var categoriesEntity = await _categorypository.ReTornaTodos();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> PegarPorId(int? id)
        {
            var categoryEntity = await _categorypository.PegaPorId(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        
       
    }

        
}
