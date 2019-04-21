using MobileClient.Infrastructure;
using MobileClient.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;

namespace MobileClient.ViewModels
{
    public class WordPageDetailViewModel : ViewModelBase
    {
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

        public WordPageDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
            Languages = new[] { Constants.Ukrainian, Constants.English };
            TranslateCommand = new DelegateCommand(async () => await TranslateTextAsync());
            SaveCommand = new DelegateCommand(async () => await SaveItemAsync());
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

        private async Task TranslateTextAsync()
        {
            var toLanguage = LanguageToString.Substring(0, 2).ToLower();
            var fromLanguage = LanguageFromString.Substring(0,2).ToLower();

            var url = String.Format("https://translate.googleapis.com/translate_a/single?ie=UTF-8&client=gtx&sl={0}&tl={1}&dt=t&q={2}", fromLanguage, toLanguage, HttpUtility.UrlEncode(Value, Encoding.UTF8));
            var webClient = new HttpClient();
            
            var result = await webClient.GetStringAsync(url);
           
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                Translation = $"Translation: {result}";
            }
            catch (Exception ex)
            {
                Translation = "Error while translating.";
            }
        }

        private long _id;
    }
}
