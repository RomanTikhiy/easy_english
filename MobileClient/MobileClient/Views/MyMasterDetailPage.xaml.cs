using Prism.Navigation;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyMasterDetailPage : IMasterDetailPageOptions
    {
		public MyMasterDetailPage ()
		{
			InitializeComponent ();
		}

        public bool IsPresentedAfterNavigation => false;
    }
}