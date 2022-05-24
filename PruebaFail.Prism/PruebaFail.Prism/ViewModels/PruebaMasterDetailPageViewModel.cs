using PruebaFail.Common.Models;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PruebaFail.Prism.ViewModels
{
    public class PruebaMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public PruebaMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        private void LoadMenus()
        {
            var menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "home",
                    PageName = "MainPage",
                    Title = "Inicio"
                },

                new Menu
                {
                    Icon = "user",
                    PageName = "ProfilePage",
                    Title = "Perfil"
                },

                new Menu
                {
                    Icon = "shop",
                    PageName = "TipoNegociosPage",
                    Title = "Tipos de locales"
                },                

                new Menu
                {
                    Icon = "help",
                    PageName = "SupportPage",
                    Title = "Ayuda y Soporte"
                },

                new Menu
                {
                    Icon = "settings",
                    PageName = "SettingPage",
                    Title = "Configuraciones"
                },

                new Menu
                {
                    Icon = "logout",
                    PageName = "LoginPage",
                    Title = "Cerrar sesión"
                }
            };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title
                }).ToList());
        }
    }
}

