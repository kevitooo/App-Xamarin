using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaFail.Web.Data;
using PruebaFail.Web.Data.Entities;
using PruebaFail.Web.Helpers;

namespace PruebaFail.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PetTypesController : Controller
    {
        private readonly DataContext _datacontext;
        private readonly IUserHelper _userHelper;

        public PetTypesController(
            DataContext context,
            IUserHelper userHelper)
        {
            _datacontext = context;
            _userHelper = userHelper;
        }

        // GET: PetTypes
        public async Task<IActionResult> Index()
        {
            return View(await _datacontext.PetTypes.ToListAsync());
        }

        // GET: PetTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petType = await _datacontext.PetTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (petType == null)
            {
                return NotFound();
            }

            return View(petType);
        }

        // GET: PetTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PetTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Local")] PetType petType)
        {
            if (ModelState.IsValid)
            {
                _datacontext.Add(petType);
                await _datacontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(petType);
        }

        // GET: PetTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petType = await _datacontext.PetTypes.FindAsync(id);
            if (petType == null)
            {
                return NotFound();
            }
            return View(petType);
        }

        // POST: PetTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Local")] PetType petType)
        {
            if (id != petType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _datacontext.Update(petType);
                    await _datacontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetTypeExists(petType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(petType);
        }

        // GET: PetTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petType = await _datacontext.PetTypes
                .FirstOrDefaultAsync(pt => pt.Id == id);
            if (petType == null)
            {
                return NotFound();
            }

            await _userHelper.DeleteUserAsync(petType.User.Email);
            _datacontext.PetTypes.Remove(petType);
            await _datacontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetTypeExists(int id)
        {
            return _datacontext.PetTypes.Any(e => e.Id == id);
        }
    }
}
