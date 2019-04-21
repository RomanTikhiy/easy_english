using EasyEnglish.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EasyEnglish.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand SettingsCommand => new Command(async () => await SettingsAsync());

        public override Task InitializeAsync(object navigationData)
        {
            IsBusy = true;

            

            return base.InitializeAsync(navigationData);
        }

        private async Task SettingsAsync()
        {
            //await NavigationService.NavigateToAsync<SettingsViewModel>();
        }
    }
}