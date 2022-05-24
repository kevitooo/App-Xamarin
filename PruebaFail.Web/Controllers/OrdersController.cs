using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaFail.Web.Data;
using PruebaFail.Web.Helpers;
using PruebaFail.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaFail.Web.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class OrdersController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IAgendaHelper _agendaHelper;
        private readonly ICombosHelper _combosHelper;

        public OrdersController(
            DataContext dataContext,
            IAgendaHelper agendaHelper,
            ICombosHelper combosHelper)
        {
            _dataContext = dataContext;
            _agendaHelper = agendaHelper;
            _combosHelper = combosHelper;
        }

        public IActionResult Index()
        {
            return View(_dataContext.Orders
                .Include(a => a.Owner)
                .ThenInclude(o => o.User)
                .Include(a => a.Product)
                .Where(a => a.Date >= DateTime.Today.ToUniversalTime()));
        }

        public async Task<IActionResult> AddDays()
        {
            await _agendaHelper.AddDaysAsync(7);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Assing(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _dataContext.Orders
                .FirstOrDefaultAsync(o => o.Id == id.Value);
            if (agenda == null)
            {
                return NotFound();
            }

            var model = new AgendaViewModel
            {
                Id = agenda.Id,
                Owner = agenda.Owner,
                Products = _combosHelper.GetComboPets(0)
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(AgendaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var agenda = await _dataContext.Orders.FindAsync(model.Id);
                if (agenda != null)
                {
                    agenda.IsAvailable = false;
                    agenda.Owner = await _dataContext.Owners.FindAsync(model.OwnerId);
                    agenda.Product = await _dataContext.Products.FindAsync(model.PetId);
                    agenda.Remarks = model.Remarks;
                    _dataContext.Orders.Update(agenda);
                    await _dataContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            model.Products = _combosHelper.GetComboPets(model.OwnerId);

            return View(model);
        }

        public async Task<JsonResult> GetPetsAsync(int ownerId)
        {
            var pets = await _dataContext.Products
                .Where(p => p.Owner.Id == ownerId)
                .OrderBy(p => p.Name)
                .ToListAsync();
            return Json(pets);
        }

        public async Task<IActionResult> Unassign(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _dataContext.Orders
                .Include(a => a.Owner)
                .Include(a => a.Product)
                .FirstOrDefaultAsync(o => o.Id == id.Value);
            if (agenda == null)
            {
                return NotFound();
            }

            agenda.IsAvailable = true;
            agenda.Product = null;
            agenda.Owner = null;
            agenda.Remarks = null;

            _dataContext.Orders.Update(agenda);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}