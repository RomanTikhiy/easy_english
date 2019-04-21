using Prism.Navigation;

namespace MobileClient.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Easy english";
        }
    }
}
