using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.Services;
using WebApplication1.Application.ViewModels;

namespace WebApplication1.Controllers
{
    public class ManutencaoController : Controller
    {
        private readonly ManutencaoService _service;
        private readonly ItemService _itemService;

        public ManutencaoController(ManutencaoService service, ItemService itemService)
        {
            _service = service;
            _itemService = itemService;
        }

        public async Task<IActionResult> Index(int itemId)
        {
            var manutencoes = await _service.GetByItemIdAsync(itemId);

            var model = manutencoes.Select(m => new ManutencaoViewModel
            {
                Id = m.Id,
                ItemId = m.ItemId,
                ItemModelo = m.Item.Modelo,
                Observacao = m.Observacao,
                DataInicio = m.DataInicio,
                DataFim = m.DataFim,
                Status = m.Status
            }).ToList();

            ViewBag.ItemId = itemId;

            return View(model);
        }

       
        public async Task<IActionResult> Details(int id)
        {
            var manutencao = await _service.GetByIdAsync(id);

            if (manutencao == null)
            {
                return NotFound();
            }

            var model = new ManutencaoViewModel
            {
                Id = manutencao.Id,
                ItemId = manutencao.ItemId,
                ItemModelo = manutencao.Item?.Modelo,
                Observacao = manutencao.Observacao,
                DataInicio = manutencao.DataInicio,
                DataFim = manutencao.DataFim,
                Status = manutencao.Status
            };

            return View(model);
        }

        public async Task<IActionResult> Create(int? itemId)
        {
            var itens = await _itemService.GetAllAsync();
            ViewBag.Items = itens;

            var model = new ManutencaoCreateUpdateViewModel();
            if (itemId.HasValue)
            {
                model.ItemId = itemId.Value;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ManutencaoCreateUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Items = await _itemService.GetAllAsync();
                return View(model);
            }

            await _service.CreateAsync(model);

            return RedirectToAction(nameof(Index), new { itemId = model.ItemId });
        }

       
        public async Task<IActionResult> Edit(int id)
        {
            var manutencao = await _service.GetByIdAsync(id);

            if (manutencao == null)
            {
                return NotFound();
            }

            var itens = await _itemService.GetAllAsync();
            ViewBag.Items = itens;

            var model = new ManutencaoCreateUpdateViewModel
            {
                Id = manutencao.Id,
                ItemId = manutencao.ItemId,
                Observacao = manutencao.Observacao,
                DataInicio = manutencao.DataInicio,
                DataFim = manutencao.DataFim,
                Status = manutencao.Status
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ManutencaoCreateUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Items = await _itemService.GetAllAsync();
                return View(model);
            }

            await _service.UpdateAsync(model);

            return RedirectToAction(nameof(Index), new { itemId = model.ItemId });
        }

       
        public async Task<IActionResult> Delete(int id)
        {
            var manutencao = await _service.GetByIdAsync(id);

            if (manutencao == null)
            {
                return NotFound();
            }

            var model = new ManutencaoViewModel
            {
                Id = manutencao.Id,
                ItemId = manutencao.ItemId,
                ItemModelo = manutencao.Item?.Modelo,
                Observacao = manutencao.Observacao,
                DataInicio = manutencao.DataInicio,
                DataFim = manutencao.DataFim,
                Status = manutencao.Status
            };

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manutencao = await _service.GetByIdAsync(id);
            
            if (manutencao == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index), new { itemId = manutencao.ItemId });
        }
    }
}