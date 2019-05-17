using System.Collections.Generic;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;

namespace MobileClient.ViewModels
{
    public class GrammarTestViewModel : ViewModelBase
    {
        private int _q1SelectedItem;
        public int Q1SelectedItem
        {
            get { return _q1SelectedItem; }
            set { SetProperty(ref _q1SelectedItem, value); }
        }

        private int _q2SelectedItem;
        public int Q2SelectedItem
        {
            get { return _q2SelectedItem; }
            set { SetProperty(ref _q2SelectedItem, value); }
        }

        private int _q3SelectedItem;
        public int Q3SelectedItem
        {
            get { return _q3SelectedItem; }
            set { SetProperty(ref _q3SelectedItem, value); }
        }

        public ICommand CompleteTestCommand { get; set; }

        private IEnumerable<QuestionResult> answers = new List<QuestionResult>
        {
            new QuestionResult()
            {
                SelectedVariant = 1,
                IsRight = true,
                RightStringVarriant = "B"
            },
            new QuestionResult()
            {
                SelectedVariant = 2,
                IsRight = true,
                RightStringVarriant = "D"
            },
            new QuestionResult()
            {
                SelectedVariant = 3,
                IsRight = true,
                RightStringVarriant = "C"
            }
        };

        public GrammarTestViewModel(INavigationService navigationService) : base(navigationService)
        {
            CompleteTestCommand = new DelegateCommand(OnTestComplete);
        }

        private async void OnTestComplete()
        {
            var results = new List<QuestionResult>
            {
                new QuestionResult()
                {
                    SelectedVariant = Q1SelectedItem,
                    IsRight = Q1SelectedItem == 1,
                    RightStringVarriant = "b",
                    QuestionNumber = 1,
                    IconPath = Q1SelectedItem == 1 ? "check_mark.png" : "cross_mark.png"
                },
                new QuestionResult()
                {
                    SelectedVariant = Q2SelectedItem,
                    IsRight = Q2SelectedItem == 3,
                    RightStringVarriant = "d",
                    QuestionNumber = 2,
                    IconPath = Q2SelectedItem == 3 ? "check_mark.png" : "cross_mark.png"
                },
                new QuestionResult()
                {
                    SelectedVariant = Q3SelectedItem,
                    IsRight = Q3SelectedItem == 2,
                    RightStringVarriant = "c",
                    QuestionNumber = 3,
                    IconPath = Q3SelectedItem == 2 ? "check_mark.png" : "cross_mark.png"
                },
            };

            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("results", results);

            await NavigationService.NavigateAsync("GrammarTestResultsPage", navigationParameters, true);
        }
    }

    public class QuestionResult
    {
        public int SelectedVariant { get; set; }

        public bool IsRight { get; set; }

        public string RightStringVarriant { get; set; }

        public int QuestionNumber { get; set; }

        public string IconPath { get; set; }
    }
}
