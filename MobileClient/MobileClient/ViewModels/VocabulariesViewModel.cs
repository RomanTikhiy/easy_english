using MobileClient.Infrastructure;
using MobileClient.Models;
using MobileClient.Views;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MobileClient.ViewModels
{
    public class VocabulariesViewModel : ViewModelBase
    {
        private Vocabulary _selectedVocabulary;
        public Vocabulary SelectedVocabulary
        {
            get { return _selectedVocabulary; }
            set
            {
                if (value == null)
                    return;

                SetProperty(ref _selectedVocabulary, value);

                var parameters = new NavigationParameters();
                parameters.Add("Vocabulary", _selectedVocabulary);

                NavigationService.NavigateAsync(nameof(VocabularyPageDetail), parameters);

                _selectedVocabulary = null;
            }
        }

        public ObservableCollection<Vocabulary> Vocabularies { get; set; }

        public VocabulariesViewModel(INavigationService navigationService) : base(navigationService)
        {
            Vocabularies = new ObservableCollection<Vocabulary>()
            {
                new Vocabulary()
                {
                    Name = "Animals",
                    Description = "My vocabulary of animals."
                },
                new Vocabulary()
                {
                    Name = "Transports",
                    Description = "Vocabulary of different transports.",
                    WordItems = new List<WordItem>()
                    {
                        new WordItem()
                        {
                            Id = WordItem.NextId++,
                            Value = "Автомобіль",
                            Translation = "Translation: Car",
                            LanguageFrom = Constants.Ukrainian,
                            LanguageTo = Constants.English,
                            Description = $"Source: {Constants.Ukrainian}, target: {Constants.English}"
                        }
                    },
                    Count = 1
                }
            };
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
