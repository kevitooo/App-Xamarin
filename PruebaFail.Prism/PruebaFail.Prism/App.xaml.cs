using Newtonsoft.Json;
using Prism;
using Prism.Ioc;
using PruebaFail.Common.Helpers;
using PruebaFail.Common.Models;
using PruebaFail.Common.Services;
using PruebaFail.Prism.ViewModels;
using PruebaFail.Prism.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PruebaFail.Prism
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            var token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            if (Settings.IsRemembered && token?.Expiration > DateTime.Now)
            {
                await NavigationService.NavigateAsync("/PruebaMasterDetailPage/NavigationPage/MainPage");
            }
            else
            {
                await NavigationService.NavigateAsync("/NavigationPage/LoginPage");
            }

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<PruebaMasterDetailPage, PruebaMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<ProfilePage, ProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<RememberPasswordPage, RememberPasswordPageViewModel>();
            containerRegistry.RegisterForNavigation<ChangePasswordPage, ChangePasswordPageViewModel>();
            containerRegistry.RegisterForNavigation<TipoNegociosPage, TipoNegociosPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingPage, SettingPageViewModel>();
            containerRegistry.RegisterForNavigation<SupportPage, SupportPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginFacebookPage, LoginFacebookPageViewModel>();
            containerRegistry.RegisterForNavigation<LilaPage, LilaPageViewModel>();
        }
    }
}
