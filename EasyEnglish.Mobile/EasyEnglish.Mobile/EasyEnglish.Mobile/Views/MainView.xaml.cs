using EasyEnglish.ViewModels;
using EasyEnglish.ViewModels.Base;
using Xamarin.Forms;

namespace EasyEnglish.Views
{
    public partial class MainView : TabbedPage
    {
        public MainView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<MainViewModel, int>(this, MessageKeys.ChangeTab, (sender, arg) =>
            {
               switch(arg)
                {
                    
                }
            });

			//await ((CatalogViewModel)HomeView.BindingContext).InitializeAsync(null);
			//await ((BasketViewModel)BasketView.BindingContext).InitializeAsync(null);
			//await ((ProfileViewModel)ProfileView.BindingContext).InitializeAsync(null);
   //         await ((CampaignViewModel)CampaignView.BindingContext).InitializeAsync(null);
        }

        protected override async void OnCurrentPageChanged()
        {
            //base.OnCurrentPageChanged();

            //if (CurrentPage is BasketView)
            //{
            //    // Force basket view refresh every time we access it
            //    await (BasketView.BindingContext as ViewModelBase).InitializeAsync(null);
            //}
            //else if (CurrentPage is CampaignView)
            //{
            //    // Force campaign view refresh every time we access it
            //    await (CampaignView.BindingContext as ViewModelBase).InitializeAsync(null);
            //}
            //else if (CurrentPage is ProfileView)
            //{
            //    // Force profile view refresh every time we access it
            //    await (ProfileView.BindingContext as ViewModelBase).InitializeAsync(null);
            //}
        }
    }
}
