using System.Threading.Tasks;
using PruebaFail.Common.Models;
using PruebaFail.Web.Data.Entities;
using PruebaFail.Web.Models;

namespace PruebaFail.Web.Helpers
{
    public interface IConverterHelper
    {
        Task<Product> ToPetAsync(PetViewModel model, string path, bool isNew);

        PetViewModel ToPetViewModel(Product pet);

        PetResponse ToPetResponse(Product pet);

        OwnerResponse ToOwnerResposne(Owner owner);
    }
}
