using Prism.Navigation;
using PruebaFail.Common.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PruebaFail.Prism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private OwnerResponse _owner;

        public MainPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();
            Title = "Limbo";
        }

        //Trae y conserva los datos ingresados
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("owner"))
            {
                _owner = parameters.GetValue<OwnerResponse>("owner");
            }
        }

        public ObservableCollection<MainPageItemViewModel> Menus { get; set; }

        private void LoadMenus()
        {
            var menus = new List<Main>
            {
                new Main
                {
                    Image = "lila",
                    Name = "Lila",
                    Type = "Heladería",
                    Address = "Dirección: Bv. América 647",
                    Time = "Horario: 11:00 - 3:00",
                    PageName = "LilaPage"
                },

                new Main
                {
                    Image = "lila",
                    Name = "Lila",
                    Type = "Heladería",
                    Address = "Dirección: Bv. América 647",
                    Time = "Horario: 11:00 - 3:00",
                    PageName = ""
                },

                new Main
                {
                    Image = "lila",
                    Name = "Lila",
                    Type = "Heladería",
                    Address = "Dirección: Bv. América 647",
                    Time = "Horario: 11:00 - 3:00",
                    PageName = ""
                },

                new Main
                {
                    Image = "lila",
                    Name = "Lila",
                    Type = "Heladería",
                    Address = "Dirección: Bv. América 647",
                    Time = "Horario: 11:00 - 3:00",
                    PageName = ""
                },

                new Main
                {
                    Image = "lila",
                    Name = "Lila",
                    Type = "Heladería",
                    Address = "Dirección: Bv. América 647",
                    Time = "Horario: 11:00 - 3:00",
                    PageName = ""
                },

                new Main
                {
                    Image = "lila",
                    Name = "Lila",
                    Type = "Heladería",
                    Address = "Dirección: Bv. América 647",
                    Time = "Horario: 11:00 - 3:00",
                    PageName = ""
                },

                new Main
                {
                    Image = "lila",
                    Name = "Lila",
                    Type = "Heladería",
                    Address = "Dirección: Bv. América 647",
                    Time = "Horario: 11:00 - 3:00",
                    PageName = ""
                },

                new Main
                {
                    Image = "lila",
                    Name = "Lila",
                    Type = "Heladería",
                    Address = "Dirección: Bv. América 647",
                    Time = "Horario: 11:00 - 3:00",
                    PageName = ""
                },

                new Main
                {
                    Image = "lila",
                    Name = "Lila",
                    Type = "Heladería",
                    Address = "Dirección: Bv. América 647",
                    Time = "Horario: 11:00 - 3:00",
                    PageName = ""
                },

                new Main
                {
                    Image = "lila",
                    Name = "Lila",
                    Type = "Heladería",
                    Address = "Dirección: Bv. América 647",
                    Time = "Horario: 11:00 - 3:00",
                    PageName = ""
                },

                new Main
                {
                    Image = "lila",
                    Name = "Lila",
                    Type = "Heladería",
                    Address = "Dirección: Bv. América 647",
                    Time = "Horario: 11:00 - 3:00",
                    PageName = ""
                },
            };

            Menus = new ObservableCollection<MainPageItemViewModel>(
                menus.Select(m => new MainPageItemViewModel(_navigationService)
                {
                    Image = m.Image,
                    Name = m.Name,
                    Type = m.Type,
                    Address = m.Address,
                    Time = m.Time,
                    PageName = m.PageName
                }).ToList());
        }
    }
}
