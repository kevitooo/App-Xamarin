using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PruebaFail.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboPets(int ownerId);
    }
}