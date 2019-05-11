using MobileClient.Infrastructure;
using MobileClient.Models;
using MobileClient.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

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

        public ICommand AddVocabularyCommand { get; set; }

        public ObservableCollection<Vocabulary> Vocabularies { get; set; }

        public VocabulariesViewModel(INavigationService navigationService) : base(navigationService)
        {
            AddVocabularyCommand = new DelegateCommand(OnAddingVocabulary);

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

        private async void OnAddingVocabulary()
        {
            await NavigationService.NavigateAsync("EditVocabularyPage");
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.TryGetValue("AddVocabulary", out Vocabulary vocabulary))
            {
                Vocabularies.Add(vocabulary);
            }
        }
    }
}
