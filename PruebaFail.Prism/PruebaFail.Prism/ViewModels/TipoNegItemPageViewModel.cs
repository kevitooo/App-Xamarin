using Prism.Commands;
using Prism.Navigation;
using PruebaFail.Common.Helpers;
using PruebaFail.Common.Models;

namespace PruebaFail.Prism.ViewModels
{
    public class TipoNegItemPageViewModel : TiposNegocio
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectTipoCommand;

        public TipoNegItemPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectMenuCommand => _selectTipoCommand ?? (_selectTipoCommand = new DelegateCommand(SelectTipo));

        private async void SelectTipo()
        {
            if (PageName.Equals("LoginPage"))
            {
                Settings.IsRemembered = false;
                await _navigationService.NavigateAsync("/NavigationPage/LoginPage");
                return;
            }

            await _navigationService.NavigateAsync($"/TipoNegociosPage/NavigationPage/{PageName}");
        }
    }
}
