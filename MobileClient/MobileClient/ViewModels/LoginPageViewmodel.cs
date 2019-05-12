using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;

namespace MobileClient.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private string _login;
        public string Login
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { get; set; }

        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            LoginCommand = new DelegateCommand(OnLoginCommand);

            Login = "t1h4n";
            Password = "superpass2000";
        }

        private async void OnLoginCommand()
        {
            if (Login.Equals("t1h4n", StringComparison.CurrentCultureIgnoreCase) && Password.Equals("superpass2000"))            
                await NavigationService.NavigateAsync("MyMasterDetailPage/MyNavigationPage/MainPage");            
        }
    }
}
