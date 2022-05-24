using PruebaFail.Web.Data.Entities;
using PruebaFail.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaFail.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;
        private readonly Random _random;


        public SeedDb(
            DataContext context,
            IUserHelper userHelper)
        {
            _dataContext = context;
            _userHelper = userHelper; 
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRoles();
            var manager = await CheckUserAsync("Kevin Schafer", "kevin_an_98@outlook.es", "Admin");
            var customer = await CheckUserAsync("Kevin Schafer", "kschafer387@gmail.com", "Customer");
            var negocio = await CheckUserAsync("Lila", "killbeatCSGOM2@outlook.es", "Negocio");
            var delivery = await CheckUserAsync("Kevin Schafer", "martinguetta10@gmail.com", "Delivery");
            await CheckOwnerAsync(customer);
            await CheckManagerAsync(manager);
            await CheckPetTypesAsync(negocio);
            await CheckServiceTypesAsync(delivery);
            //await CheckOrdersAsync();
            await CheckProductsAsync();
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Customer");
            await _userHelper.CheckRoleAsync("Negocio");
            await _userHelper.CheckRoleAsync("Delivery");
        }

        private async Task<User> CheckUserAsync(string nombre, string email, string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Nombre = nombre,
                    Email = email,
                    UserName = email,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);

                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);

            }

            return user;
        }

        private async Task CheckOwnerAsync(User user)
        {
            if (!_dataContext.Owners.Any())
            {
                _dataContext.Owners.Add(new Owner { User = user });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckManagerAsync(User user)
        {
            if (!_dataContext.Managers.Any())
            {
                _dataContext.Managers.Add(new Manager { User = user });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckPetTypesAsync(User user)
        {
            if (!_dataContext.PetTypes.Any())
            {
                _dataContext.PetTypes.Add(new PetType { User = user });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckServiceTypesAsync(User user)
        {
            if (!_dataContext.ServiceTypes.Any())
            {
                _dataContext.ServiceTypes.Add(new ServiceType { User = user });
                await _dataContext.SaveChangesAsync();
            }
        }

        /*private async Task CheckOrdersAsync()
        {
            if (!_dataContext.Orders.Any())
            {
                var initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                var finalDate = initialDate.AddYears(1);
                while (initialDate < finalDate)
                {
                    if (initialDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        var finalDate2 = initialDate.AddHours(10);
                        while (initialDate < finalDate2)
                        {
                            _dataContext.Orders.Add(new Order
                            {
                                Date = initialDate,
                                IsAvailable = true
                            });

                            initialDate = initialDate.AddMinutes(30);
                        }

                        initialDate = initialDate.AddHours(14);
                    }
                    else
                    {
                        initialDate = initialDate.AddDays(1);
                    }
                }
            }

            await _dataContext.SaveChangesAsync();
        }*/

        private async Task CheckProductsAsync()
        {
            if (!_dataContext.Products.Any())
            {
                var petType = _dataContext.PetTypes.FirstOrDefault();
                AddProduct("Pizza de papas fritas", petType, 250);
                AddProduct("Pizza de rucula", petType, 230);
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, PetType petType, decimal price)
        {
            _dataContext.Products.Add(new Product
            {
                Name = name,
                Price = price,
                PetType = petType,
                Stock = _random.Next(100),
                IsAvailable = true
            });
        }
    }
}