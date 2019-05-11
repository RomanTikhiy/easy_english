using MobileClient.Views;
using Prism.Commands;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MobileClient.ViewModels
{
    public class TestsViewModel : ViewModelBase
    {
        public ICommand GrammarTestCommand { get; set; }

        public TestsViewModel(INavigationService navigationService) : base(navigationService)
        {
            GrammarTestCommand = new DelegateCommand(async () => await NavigateToGrammarTest());

        }
        private async Task NavigateToGrammarTest()
        {
            await NavigationService.NavigateAsync(nameof(GrammarTestPage));
        }
    }
}
