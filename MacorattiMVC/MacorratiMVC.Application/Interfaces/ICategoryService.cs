using MacorratiMVC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacorratiMVC.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> RetornaTodos();
        Task<CategoryDTO> PegarPorId(int?id);
        Task Add(CategoryDTO categoryDTO); 
        Task Update(CategoryDTO categoryDTO);
        Task Remove(int? id);
    }
}
