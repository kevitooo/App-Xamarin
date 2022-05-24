using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaFail.Web.Data;
using PruebaFail.Web.Data.Entities;
using PruebaFail.Web.Helpers;
using PruebaFail.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaFail.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManagersController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;
        private readonly IMailHelper _mailHelper;

        public ManagersController(
            DataContext dataContext,
            IUserHelper userHelper,
            IMailHelper mailHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
            _mailHelper = mailHelper;
        }

        public IActionResult Index()
        {
            return View(_dataContext.Managers.Include(m => m.User));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = await _dataContext.Managers
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.Id == id.Value);
            if (manager == null)
            {
                return NotFound();
            }

            return View(manager);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddUserViewModel view)
        {
            if (ModelState.IsValid)
            {
                var user = await AddUser(view);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Este correo ya esta en uso");
                    return View(view);
                }

                var manager = new Manager { User = user };

                _dataContext.Managers.Add(manager);
                await _dataContext.SaveChangesAsync();

                var myToken = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                var tokenLink = Url.Action("ConfirmEmail", "Account", new
                {
                    userid = user.Id,
                    token = myToken
                }, protocol: HttpContext.Request.Scheme);

                _mailHelper.SendMail(view.Username, "Confirmación de correo electrónico", $"<h1>Activa tu cuenta de Limbo</h1>" +
                    $"Bienvenido a Limbo, " +
                    $"solo necesitas confirmar tu correo electrónico y activarás tu cuenta haciendo click en este enlace:</br></br><a href = \"{tokenLink}\">Confirma tu correo electrónico</a>");

                return RedirectToAction(nameof(Index));
            }

            return View(view);
        }

        private async Task<User> AddUser(AddUserViewModel view)
        {
            var user = new User
            {
                Email = view.Username,
                Nombre = view.Nombre,
                UserName = view.Username
            };

            var result = await _userHelper.AddUserAsync(user, view.Password);
            if (result != IdentityResult.Success)
            {
                return null;
            }

            var newUser = await _userHelper.GetUserByEmailAsync(view.Username);
            await _userHelper.AddUserToRoleAsync(newUser, "Admin");
            return newUser;
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = await _dataContext.Managers
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manager == null)
            {
                return NotFound();
            }

            var view = new EditUserViewModel
            {
                Nombre = manager.User.Nombre,
                Id = manager.Id
            };

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel view)
        {
            if (ModelState.IsValid)
            {
                var owner = await _dataContext.Owners
                    .Include(o => o.User)
                    .FirstOrDefaultAsync(o => o.Id == view.Id);

                owner.User.Nombre = view.Nombre;

                await _userHelper.UpdateUserAsync(owner.User);
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

            var manager = await _dataContext.Managers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manager == null)
            {
                return NotFound();
            }

            _dataContext.Managers.Remove(manager);
            await _dataContext.SaveChangesAsync();
            await _userHelper.DeleteUserAsync(manager.User.Email);
            return RedirectToAction(nameof(Index));
        }

        private bool ManagerExists(int id)
        {
            return _dataContext.Managers.Any(e => e.Id == id);
        }
    }
}

