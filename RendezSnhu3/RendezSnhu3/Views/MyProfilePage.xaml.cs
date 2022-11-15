using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RendezSnhu3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyProfilePage : ContentPage
    {
        public MyProfilePage()
        {
            InitializeComponent();
        }

        private async void LogoutClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Are you sure you want to logout?","You will be returned to the login screen.","Yes", "No");
            if (answer)
            {
                await Shell.Current.GoToAsync($"//SignInPage");
            }
        }
    }
}