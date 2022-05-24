using Prism.Commands;
using Prism.Navigation;
using PruebaFail.Common.Helpers;
using PruebaFail.Common.Models;
using PruebaFail.Common.Services;
using System.Threading.Tasks;

namespace PruebaFail.Prism.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _registerCommand;

        public RegisterPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;

            Title = "Crear tu cuenta de Limbo";
            IsEnabled = true;
        }

        public DelegateCommand RegisterCommand => _registerCommand ?? (_registerCommand = new DelegateCommand(Register));

        public string Nombre { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private async void Register()
        {
            var isValid = await ValidateData();
            if (!isValid)
            {
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            var request = new UserRequest
            {
                Email = Email,
                Nombre = Nombre,
                Password = Password
            };

            var url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiService.RegisterUserAsync(
                url,
                "api",
                "/Account",
                request);

            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Aceptar");
                return;
            }

            await App.Current.MainPage.DisplayAlert(
                "Hecho",
                response.Message,
                "Aceptar");
            await _navigationService.GoBackAsync();
        }

        private async Task<bool> ValidateData()
        {
            if (string.IsNullOrEmpty(Email) || !RegexHelper.IsValidEmail(Email))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error", 
                    "Debes poner un correo válido", 
                    "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(Nombre))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error", 
                    "Debes completar con tu nombre", 
                    "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(Password) || Password.Length < 6)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error", 
                    "Debes poner una contraseña con al menos 6 caracteres", 
                    "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(PasswordConfirm))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error", 
                    "Debes confirmar la contraseña", 
                    "Aceptar");
                return false;
            }

            if (!Password.Equals(PasswordConfirm))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error", 
                    "La contraseña y la confirmación no son iguales", 
                    "Aceptar");
                return false;
            }

            return true;
        }
    }
}

