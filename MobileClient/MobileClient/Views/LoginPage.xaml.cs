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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void OnShowPass(object sender, EventArgs e)
        {
            var changeImge = !password.IsPassword;

            password.IsPassword = changeImge;

            if (!changeImge)
                hidePassImage.Source = "eye.png";
            else
                hidePassImage.Source = "hide_pass.png";
        }
    }
}