using MobileClient.Models;
using MobileClient.Views;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MobileClient.ViewModels
{
    public class VocabularyPageDetailViewModel : ViewModelBase
    {
        public ICommand NewWordItemCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ICommand EditCommand { get; set; }

        private WordItem _selectedWord;
        public WordItem SelectedWord
        {
            get { return _selectedWord; }
            set
            {
                if (value == null)
                    return;

                SetProperty(ref _selectedWord, value);

                var parameters = new NavigationParameters();
                parameters.Add("Word", _selectedWord);

                NavigationService.NavigateAsync(nameof(WordPageDetail), parameters);

                _selectedWord = null;
            }
        }

        private Vocabulary _vocabulary;

        private ObservableCollection<WordItem> _words;
        public ObservableCollection<WordItem> Words
        {
            get { return _words; }
            set { SetProperty(ref _words, value); }
        }

        public VocabularyPageDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
            NewWordItemCommand = new DelegateCommand(async () => await AddNewWordItemAsync());
            DeleteCommand = new DelegateCommand<WordItem>(DeleteItem);
            EditCommand = new DelegateCommand(async () => await EditVocabularyAsync());
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.TryGetValue("Vocabulary", out Vocabulary vocabulary))
            {
                _vocabulary = vocabulary;
                Words = new ObservableCollection<WordItem>(vocabulary.WordItems);
            }

            if (parameters.TryGetValue("EditWordItem", out WordItem editedWord))
            {
                var word = Words.FirstOrDefault(x => x.Id == editedWord.Id);
                word.Value = editedWord.Value;
                word.LanguageFrom = editedWord.LanguageFrom;
                word.LanguageTo = editedWord.LanguageTo;
                word.Translation = editedWord.Translation;
                word.Description = editedWord.Description;
            }

            if (parameters.TryGetValue("AddWordItem", out WordItem addedWord))
            {
                Words.Add(addedWord);
                _vocabulary.WordItems.Add(addedWord);
                _vocabulary.Count = _vocabulary.WordItems.Count;
            }
        }

        private async Task AddNewWordItemAsync()
        {
            await NavigationService.NavigateAsync(nameof(WordPageDetail));
        }

        private async Task EditVocabularyAsync()
        {
            await NavigationService.NavigateAsync(nameof(EditVocabularyPage));
        }

        private void DeleteItem(WordItem item)
        {
            Words.Remove(item);
            _vocabulary.WordItems.Remove(item);
            _vocabulary.Count = _vocabulary.WordItems.Count;
        }
    }
}
