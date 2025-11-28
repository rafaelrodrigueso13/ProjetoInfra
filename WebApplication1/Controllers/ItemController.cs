using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Services;
using WebApplication1.Application.ViewModels;

namespace WebApplication1.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemService _service;

        public ItemController(ItemService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _service.GetAllAsync();

            var model = items.Select(i => new ItemViewModel
            {
                Id = i.Id,
                Modelo = i.Modelo,
                Categoria = i.Categoria,
                Patrimonio = i.Patrimonio,
                NumeroSerie = i.NumeroSerie
            });

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SearchItems(string searchTerm)
        {
            var items = await _service.SearchAsync(searchTerm ?? "");

            var model = items.Select(i => new ItemViewModel
            {
                Id = i.Id,
                Modelo = i.Modelo,
                Categoria = i.Categoria,
                Patrimonio = i.Patrimonio,
                NumeroSerie = i.NumeroSerie
            });

            return PartialView("_ItemListPartial", model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ItemCreateUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var dto = new ItemDto
            {
                Modelo = model.Modelo,
                Categoria = model.Categoria,
                Patrimonio = model.Patrimonio,
                NumeroSerie = model.NumeroSerie
            };

            await _service.AddAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            var model = new ItemCreateUpdateViewModel
            {
                Id = item.Id,
                Modelo = item.Modelo,
                Categoria = item.Categoria,
                Patrimonio = item.Patrimonio,
                NumeroSerie = item.NumeroSerie
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ItemCreateUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var dto = new ItemDto
            {
                Id = model.Id,
                Modelo = model.Modelo,
                Categoria = model.Categoria,
                Patrimonio = model.Patrimonio,
                NumeroSerie = model.NumeroSerie
            };

            await _service.UpdateAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            var model = new ItemViewModel
            {
                Id = item.Id,
                Modelo = item.Modelo,
                Categoria = item.Categoria,
                Patrimonio = item.Patrimonio,
                NumeroSerie = item.NumeroSerie
            };

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            var model = new ItemViewModel
            {
                Id = item.Id,
                Modelo = item.Modelo,
                Categoria = item.Categoria,
                Patrimonio = item.Patrimonio,
                NumeroSerie = item.NumeroSerie
            };

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}