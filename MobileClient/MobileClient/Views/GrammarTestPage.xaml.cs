using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GrammarTestPage : CarouselPage
    {
		public GrammarTestPage ()
		{
			InitializeComponent ();
		}

        private void OnButtonNextPressed(object sender, EventArgs e)
        {
            var pageCount = carousel.Children.Count;
            if (pageCount < 2)
                return;

            var index = carousel.Children.IndexOf(carousel.CurrentPage);
            index++;
            if (index >= pageCount)
                index = 0;

            carousel.CurrentPage = carousel.Children[index];
        }

        private void OnButtonPrevPressed(object sender, EventArgs e)
        {
            var pageCount = carousel.Children.Count;
            if (pageCount < 2)
                return;

            var index = carousel.Children.IndexOf(carousel.CurrentPage);
            index--;
            if (index <= 0)
                index = 0;

            carousel.CurrentPage = carousel.Children[index];
        }
    }
}