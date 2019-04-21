using MobileClient.Abstractions;
using MobileClient.Infrastructure;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Windows.Input;

namespace MobileClient.ViewModels
{
    public class TranslatePageViewModel : ViewModelBase
    {
        readonly ITranslator _translator;

        string _textToTranslate;

        private IEnumerable<string> _languages;
        public IEnumerable<string> Languages
        {
            get { return _languages; }
            set { SetProperty(ref _languages, value); }
        }

        private string _languageToString;
        public string LanguageToString
        {
            get { return _languageToString; }
            set { SetProperty(ref _languageToString, value); }
        }

        private string _languageFromString;
        public string LanguageFromString
        {
            get { return _languageFromString; }
            set { SetProperty(ref _languageFromString, value); }
        }

        private string _translation;
        public string Translation
        {
            get { return _translation; }
            set { SetProperty(ref _translation, value); }
        }

        public ICommand TranslateCommand { get; set; }

        public TranslatePageViewModel(INavigationService navigationService, ITranslator translator) : base(navigationService)
        {
            _translator = translator;

            Languages = new[] { Constants.Ukrainian, Constants.English };

            TranslateCommand = new DelegateCommand(async () =>
            {
                if (!string.IsNullOrEmpty(_textToTranslate) && LanguageFromString != LanguageToString)
                    Translation = await _translator.TranslateAsync(LanguageFromString.Substring(0, 2).ToLower(),
                        LanguageToString.Substring(0, 2).ToLower(), _textToTranslate.Replace("\n", " "));
            });
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.TryGetValue("text", out string value))            
                _textToTranslate = value;           
        }
    }
}
