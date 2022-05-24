using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebaFail.Prism.ViewModels
{
    public class SettingPageViewModel : ViewModelBase
    {
        public SettingPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Configuraciones";
        }
    }
}
