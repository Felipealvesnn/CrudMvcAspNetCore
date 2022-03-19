using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacorratiMVC.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Nome é Obrigatorio"),MinLength(3), MaxLength(100), Display(Name = "Nome da Categoria")]
        public string Name { get; set; }    

    }
}
