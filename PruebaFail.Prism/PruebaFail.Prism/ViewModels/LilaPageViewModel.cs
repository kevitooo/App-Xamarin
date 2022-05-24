using Prism.Navigation;

namespace PruebaFail.Prism.ViewModels
{
    public class LilaPageViewModel : ViewModelBase
    {
        public LilaPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Heladeria Lila";
        }
    }
}
