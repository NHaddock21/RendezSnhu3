using MySql.Data.MySqlClient;
using RendezSnhu3;
using RendezSnhu3.Model;
using RendezSnhu3.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace RendezSnhu3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class SignInPage : ContentPage
    {
        int signedIn = 1;

        Database data = new Database();
        public SignInPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<CreateAccountPage>(this, "Hi", (sender) => {
                Notificationtxt.TextColor = Color.Green;
                Notificationtxt.Text = "Account Successfully Created!";
            });
            MessagingCenter.Subscribe<Database>(this, "Error", (sender) => {
                Notificationtxt.TextColor = Color.Red;
                Notificationtxt.Text = "Incorrect Email or Password";
            });

           
        }
        private async void CreateAccountClicked(object sender, EventArgs e)
        {
            Notificationtxt.Text = "";
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
                Notificationtxt.Text = "";
                await data.UserLogIn(emailtxt, passtxt);
            }
            else if (usernametxt.Text == null || passwordtxt.Text == null)
            {
                Notificationtxt.TextColor = Color.Red;
                Notificationtxt.Text = "Please Fill Out Both Fields";
            }
        }
    }
}