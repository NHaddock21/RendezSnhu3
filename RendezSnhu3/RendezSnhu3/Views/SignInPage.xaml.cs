using MySql.Data.MySqlClient;
using RendezSnhu3;
using RendezSnhu3.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace RendezSnhu3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class SignInPage : ContentPage
    {
        Database data = new Database();
        public SignInPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<CreateAccountPage>(this, "Hi", (sender) => {
                Notificationtxt.Text = "Account Successfully Created!";
            });
        }
        private async void CreateAccountClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//SignInPage/CreateAccountPage");
        }

        private async void SignInClicked(object sender, EventArgs e)
        {
            if (usernametxt.Text != null & passwordtxt.Text != null)
            {
                string emailtxt = usernametxt.Text.ToString();
                string passtxt = passwordtxt.Text.ToString();
                usernametxt.Text = "";
                passwordtxt.Text = "";
                await data.UserLogIn(emailtxt, passtxt);
            }
        }
    }
}