using MacorratiMVC.Application.DTOs;
using MacorratiMVC.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MacorattiMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _ICategoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _ICategoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _ICategoryService.RetornaTodos();
            if (categories == null)
            
            {
                return NotFound("categories notfound");
            }
            return Ok(categories);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>>Get(int Id) 
        {
            var category= await _ICategoryService.PegarPorId(Id);
            if (category == null)

            {
                return NotFound("categories notfound");
            }
            return Ok(category);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null)
                return BadRequest("Invalid Data");

            await _ICategoryService.Add(categoryDto);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.Id },
                categoryDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (id != categoryDto.Id)
                return BadRequest();

            if (categoryDto == null)
                return BadRequest();

            await _ICategoryService.Update(categoryDto);

            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = await _ICategoryService.PegarPorId(id);
            if (category == null)
            {
                return NotFound("Category not found");
            }

            await _ICategoryService.Remove(id);

            return Ok(category);

        }
    }
}