using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaFail.Web.Data;
using PruebaFail.Web.Data.Entities;
using PruebaFail.Web.Helpers;
using PruebaFail.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaFail.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OwnersController : Controller
    {
        private readonly DataContext _datacontext;
        private readonly IUserHelper _userHelper;
        private readonly IMailHelper _mailHelper;

        public OwnersController(
            DataContext context,
            IUserHelper userHelper,
            IMailHelper mailHelper)
        {
            _datacontext = context;
            _userHelper = userHelper;
            _mailHelper = mailHelper;
        }

        // GET: Owners
        public IActionResult Index()
        {
            return View(_datacontext.Owners.Include(o => o.User));
        }

        // GET: Owners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _datacontext.Owners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // GET: Owners/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Username,
                    Nombre = model.Nombre,
                    Email = model.Username
                };
                var response = await _userHelper.AddUserAsync(user, model.Password);
                if (response.Succeeded)
                {
                    var userInDB = await _userHelper.GetUserByEmailAsync(model.Username);
                    await _userHelper.AddUserToRoleAsync(userInDB, "Customer");

                    var owner = new Owner
                    {
                        User = userInDB
                    };

                    _datacontext.Owners.Add(owner);

                    try
                    {

                        await _datacontext.SaveChangesAsync();

                        var myToken = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                        var tokenLink = Url.Action("ConfirmEmail", "Account", new
                        {
                            userid = user.Id,
                            token = myToken
                        }, protocol: HttpContext.Request.Scheme);

                        _mailHelper.SendMail(model.Username, "Confirmación de correo electrónico", $"<h1>Activa tu cuenta de Limbo</h1>" +
                            $"Bienvenido a Limbo, " +
                            $"solo necesitas confirmar tu correo electrónico y activarás tu cuenta haciendo click en este enlace:</br></br><a href = \"{tokenLink}\">Confirma tu correo electrónico</a>");

                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, ex.ToString());
                    }
                }
                ModelState.AddModelError(string.Empty, response.Errors.FirstOrDefault().Description);
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _datacontext.Owners
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.Id == id.Value);
            if (owner == null)
            {
                return NotFound();
            }

            var model = new EditUserViewModel
            {
                Nombre = owner.User.Nombre,
                Id = owner.Id
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var owner = await _datacontext.Owners
                    .Include(o => o.User)
                    .FirstOrDefaultAsync(o => o.Id == model.Id);

                owner.User.Nombre = model.Nombre;

                await _userHelper.UpdateUserAsync(owner.User);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }


        // GET: Owners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _datacontext.Owners
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.Id == id);
            if (owner == null)
            {
                return NotFound();
            }

            await _userHelper.DeleteUserAsync(owner.User.Email);
            _datacontext.Owners.Remove(owner);
            await _datacontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnerExists(int id)
        {
            return _datacontext.Owners.Any(e => e.Id == id);
        }
    }
}
