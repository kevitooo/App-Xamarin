using Prism.Commands;
using Prism.Navigation;
using PruebaFail.Common.Helpers;
using PruebaFail.Common.Models;

namespace PruebaFail.Prism.ViewModels
{
    public class MainPageItemViewModel : Main
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectMenuCommand;

        public MainPageItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectMenuCommand => _selectMenuCommand ?? (_selectMenuCommand = new DelegateCommand(SelectMenu));

        private async void SelectMenu()
        {
            if (PageName.Equals("LoginPage"))
            {
                Settings.IsRemembered = false;
                await _navigationService.NavigateAsync("/NavigationPage/LoginPage");
                return;
            }

            await _navigationService.NavigateAsync($"/MainPage/NavigationPage/{PageName}");

        }
    }
}
