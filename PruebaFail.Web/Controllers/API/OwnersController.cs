using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaFail.Common.Models;
using PruebaFail.Models;
using PruebaFail.Web.Data;
using PruebaFail.Web.Data.Entities;
using PruebaFail.Web.Helpers;
using System;
using System.Threading.Tasks;

namespace PruebaFail.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OwnersController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public OwnersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        [Route("GetOwnerByEmail")]
        public async Task<IActionResult> GetOwner(EmailRequest emailRequest)
        {
            var owner = await _dataContext.Owners
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.User.UserName.ToLower().Equals(emailRequest.Email.ToLower()));

            var response = new OwnerResponse
            {
                Id = owner.Id,
                Nombre = owner.User.Nombre,
                Email = owner.User.Email
            };
            return Ok(response);
        }
    }
}

