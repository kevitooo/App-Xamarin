using Prism.Navigation;
using PruebaFail.Common.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PruebaFail.Prism.ViewModels
{
    public class TipoNegociosPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public TipoNegociosPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();
            Title = "Tipos de negocios";
        }

        public ObservableCollection<TipoNegItemPageViewModel> Menus { get; set; }

        private void LoadMenus()
        {
            var menus = new List<TiposNegocio>
            {
                new TiposNegocio
                {
                    Icon = "comidarapida",
                    PageName = "",
                    Title = "Comida Rápida"
                },

                new TiposNegocio
                {
                    Icon = "helado",
                    PageName = "",
                    Title = "Heladerías"
                },

                new TiposNegocio
                {
                    Icon = "pizzeria",
                    PageName = "",
                    Title = "Pizzerías"
                },

                new TiposNegocio
                {
                    Icon = "vianda",
                    PageName = "",
                    Title = "Viandas"
                },

                new TiposNegocio
                {
                    Icon = "spaguetti", 
                    PageName = "",
                    Title = "Rotiserías"
                },

                new TiposNegocio
                {
                    Icon = "restaurante",
                    PageName = "",
                    Title = "Restaurantes"
                },

                new TiposNegocio
                {
                    Icon = "martini",
                    PageName = "",
                    Title = "Bares"
                },
            };

            Menus = new ObservableCollection<TipoNegItemPageViewModel>(
                menus.Select(m => new TipoNegItemPageViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title
                }).ToList());
        }
    }
}
