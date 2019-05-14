using MobileClient.Abstractions;
using MobileClient.Infrastructure;
using MobileClient.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileClient.ViewModels
{
    public class WordPageDetailViewModel : ViewModelBase
    {
        readonly ITranslator _translator;

        #region Properties

        private IEnumerable<string> _languages;
        public IEnumerable<string> Languages
        {
            get { return _languages; }
            set { SetProperty(ref _languages, value); }
        }

        private string _value;
        public string Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }

        private string _translation;
        public string Translation
        {
            get { return _translation; }
            set { SetProperty(ref _translation, value); }
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

        #endregion
        public ICommand SaveCommand { get; set; }

        public ICommand TranslateCommand { get; set; }

        public ICommand TextToSpeechCommand { get; set; }

        public ICommand ResultTextToSpeechCommand { get; set; }

        public WordPageDetailViewModel(INavigationService navigationService, ITranslator translator) : base(navigationService)
        {
            _translator = translator;

            Languages = new[] { Constants.Ukrainian, Constants.English };

            TextToSpeechCommand = new DelegateCommand(OnTextToSpeech);
            ResultTextToSpeechCommand = new DelegateCommand(OnResultTextToSpeech);

            TranslateCommand = new DelegateCommand(async () => 
            {
                var toLanguage = LanguageToString.Substring(0, 2).ToLower();
                var fromLanguage = LanguageFromString.Substring(0, 2).ToLower();

                var result = await _translator.TranslateAsync(fromLanguage, toLanguage, Value);

                Translation = result;
            });

            SaveCommand = new DelegateCommand(async () => await SaveItemAsync());
        }

        private void OnResultTextToSpeech()
        {
            DependencyService.Get<ITextToSpeech>().Speak(Translation, LanguageToString.StartsWith("Uk") ? "uk-UA" : "en-US");
        }

        private void OnTextToSpeech()
        {
            DependencyService.Get<ITextToSpeech>().Speak(Value, LanguageFromString.StartsWith("Uk") ? "uk-UA": "en-US");
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);

            _id = 0;
            Value = Translation = LanguageFromString = LanguageToString = string.Empty;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.TryGetValue("Word", out WordItem word))
            {

                _id = word.Id;
                Value = word.Value;
                Translation = word.Translation;
                LanguageFromString = word.LanguageFrom;
                LanguageToString = word.LanguageTo;
            }
        }

        private async Task SaveItemAsync()
        {
            var item = new WordItem()
            {
                Value = Value,
                Translation = Translation,
                LanguageFrom = LanguageFromString,
                LanguageTo = LanguageToString,
                Description = $"Source: {LanguageFromString}, target: {LanguageToString}"
            };

            var navParameters = new NavigationParameters();

            if (_id != 0)
            {
                item.Id = _id;
                navParameters.Add("EditWordItem", item);
            }
            else
            {
                item.Id = WordItem.NextId++;
                navParameters.Add("AddWordItem", item);
            }

            await NavigationService.GoBackAsync(navParameters);
        }        

        private long _id;
    }
}
