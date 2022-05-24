using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebaFail.Prism.ViewModels
{
    public class SupportPageViewModel : ViewModelBase
    {
        public SupportPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Ayuda y soporte";
        }
    }
}
