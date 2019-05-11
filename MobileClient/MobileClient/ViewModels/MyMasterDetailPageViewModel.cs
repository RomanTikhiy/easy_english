using MobileClient.Models;
using Prism.Commands;
using Prism.Navigation;

namespace MobileClient.ViewModels
{
    public class MyMasterDetailPageViewModel : ViewModelBase
    {
        private MasterPageItem _selectedItem;
        public MasterPageItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _selectedItem, value);
                    Navigate(value.NavigationPath);

                    _selectedItem = null;
                }
            }
        }        

        public MyMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
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
