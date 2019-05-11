using MobileClient.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Windows.Input;

namespace MobileClient.ViewModels
{
    public class EditVocabularyViewModel : ViewModelBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private Vocabulary _vocabulary;

        public ICommand SaveVocabularyCommand { get; set; }

        public EditVocabularyViewModel(INavigationService navigationService) : base(navigationService)
        {
            SaveVocabularyCommand = new DelegateCommand(OnSavingVocabulary);
        }

        private async void OnSavingVocabulary()
        {
            if (_vocabulary != null)
            {
                _vocabulary.Name = Name;
                _vocabulary.Description = Description;

                var parameters = new NavigationParameters();
                parameters.Add("EditVocabulary", _vocabulary);

                await NavigationService.GoBackAsync(parameters);
            }
            else
            {
                var vocabulary = new Vocabulary();
                vocabulary.Name = Name;
                vocabulary.Description = Description;

                var parameters = new NavigationParameters();
                parameters.Add("AddVocabulary", vocabulary);

                await NavigationService.GoBackAsync(parameters);
            }
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("EditVocabulary"))
            {
                _vocabulary = (Vocabulary)parameters["EditVocabulary"];

                Name = _vocabulary.Name;
                Description = _vocabulary.Description;
            }
        }
    }
}
