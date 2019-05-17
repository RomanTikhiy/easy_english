using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MobileClient.ViewModels
{
    public class GrammarTestResultsViewModel : ViewModelBase
    {
        public ObservableCollection<QuestionResult> Results { get; set; }

        public GrammarTestResultsViewModel(INavigationService navigationService) : base(navigationService)
        {
            Results = new ObservableCollection<QuestionResult>();
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.TryGetValue("results", out IEnumerable<QuestionResult> results))
            {
                foreach (var res in results)
                {
                    Results.Add(res);
                }
            }
        }
    }
}
