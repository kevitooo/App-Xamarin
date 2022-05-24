using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaFail.Web.Data;
using PruebaFail.Web.Data.Entities;
using PruebaFail.Web.Helpers;
using PruebaFail.Web.Models;
using System.Threading.Tasks;

namespace PruebaFail.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly ICombosHelper _combosHelper;
        private readonly DataContext _dataContext;

        public ProductsController(
            ICombosHelper combosHelper,
            DataContext dataContext)
        {
            _combosHelper = combosHelper;
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View(_dataContext.Products
                .Include(p => p.Owner)
                .ThenInclude(o => o.User)
                .Include(p => p.PetType));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _dataContext.Products
                .Include(p => p.Owner)
                .ThenInclude(o => o.User)
                .FirstOrDefaultAsync(o => o.Id == id.Value);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _dataContext.Products
                .Include(p => p.Owner)
                .Include(p => p.PetType)
                .FirstOrDefaultAsync(p => p.Id == id.Value);
            if (pet == null)
            {
                return NotFound();
            }

            var view = new PetViewModel
            {
                Price = pet.Price,
                Id = pet.Id,
                Name = pet.Name,
                OwnerId = pet.Owner.Id,
                PetTypeId = pet.PetType.Id,
                Stock = pet.Stock,
                IsAvailable = pet.IsAvailable
            };

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PetViewModel view)
        {
            if (ModelState.IsValid)
            {
                var pet = new Product
                {
                    Price = view.Price,
                    Id = view.Id,
                    Name = view.Name,
                    Owner = await _dataContext.Owners.FindAsync(view.OwnerId),
                    PetType = await _dataContext.PetTypes.FindAsync(view.PetTypeId),
                    Stock = view.Stock,
                    IsAvailable = view.IsAvailable
                };

                _dataContext.Products.Update(pet);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(view);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _dataContext.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pet == null)
            {
                return NotFound();
            }

            _dataContext.Products.Remove(pet);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}