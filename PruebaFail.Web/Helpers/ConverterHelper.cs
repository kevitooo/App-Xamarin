using System.Threading.Tasks;
using PruebaFail.Common.Models;
using PruebaFail.Web.Data;
using PruebaFail.Web.Data.Entities;
using PruebaFail.Web.Models;

namespace PruebaFail.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(
            DataContext dataContext,
            ICombosHelper combosHelper)
        {
            _dataContext = dataContext;
            _combosHelper = combosHelper;
        }

        public async Task<Product> ToPetAsync(PetViewModel model, string path, bool isNew)
        {
            var pet = new Product
            {
                Orders = model.Orders,
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                Owner = await _dataContext.Owners.FindAsync(model.OwnerId),
                PetType = await _dataContext.PetTypes.FindAsync(model.PetTypeId),
                Price = model.Price,
                IsAvailable = model.IsAvailable,
                Stock = model.Stock
            };

            return pet;
        }

        public PetViewModel ToPetViewModel(Product pet)
        {
            return new PetViewModel
            {
                Orders = pet.Orders,
                Price = pet.Price,
                Name = pet.Name,
                Owner = pet.Owner,
                PetType = pet.PetType,
                Stock = pet.Stock,
                IsAvailable = pet.IsAvailable,
                Id = pet.Id,
                OwnerId = pet.Owner.Id,
                PetTypeId = pet.PetType.Id
            };
        }

        public PetResponse ToPetResponse(Product pet)
        {
            if (pet == null)
            {
                return null;
            }

            return new PetResponse
            {
                Price = pet.Price,
                Id = pet.Id,
                Name = pet.Name,
                Stock = pet.Stock,
                IsAvailable = pet.IsAvailable
            };
        }

        public OwnerResponse ToOwnerResposne(Owner owner)
        {
            if (owner == null)
            {
                return null;
            }

            return new OwnerResponse
            {
                Nombre = owner.User.Nombre,
                Email = owner.User.Email
            };
        }
    }
}