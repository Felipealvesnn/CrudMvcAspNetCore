using MacorratiMVC.Application.DTOs;
using MacorratiMVC.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MacorattiMVC.WebUI.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _ICategoryService;

        public CategoryController(ICategoryService CategoryService)
        {
            _ICategoryService = CategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categorias = await _ICategoryService.RetornaTodos();
            return View(categorias);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                await _ICategoryService.Add(categoryDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(categoryDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null) return NotFound();
            var categoria = await _ICategoryService.PegarPorId(Id);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                try { await _ICategoryService.Update(categoryDTO); }
                catch (Exception) { throw; }

                return RedirectToAction(nameof(Index));
            }
            return View(categoryDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null) return NotFound();
            var categoria = await _ICategoryService.PegarPorId(Id);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? Id)
        {
            await _ICategoryService.Remove(Id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null) return NotFound();
            var categoria = await _ICategoryService.PegarPorId(Id);
            if (categoria == null) return NotFound();
            return View(categoria);
        }
    }
}