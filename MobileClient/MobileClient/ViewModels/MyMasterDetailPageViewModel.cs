using Prism.Commands;
using Prism.Navigation;

namespace MobileClient.ViewModels
{
    public class MyMasterDetailPageViewModel : ViewModelBase
    {
        public DelegateCommand<string> NavigateCommand { get; set; }

        public MyMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private async void Navigate(string name)
        {
            var result = await NavigationService.NavigateAsync(name);
            if (!result.Success)
            {

            }
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }
    }
}
