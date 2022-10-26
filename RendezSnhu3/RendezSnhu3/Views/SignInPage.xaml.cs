using MySql.Data.MySqlClient;
using RendezSnhu3;
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

        DatabaseConnection datacheck = new DatabaseConnection();
        Data data = new Data();
        public SignInPage()
        {
            InitializeComponent();
        }

        private void SignInClick(object sender, EventArgs e)
        {
            if (usernametxt.Text != null & passwordtxt.Text != null)
            {

                string emailtxt = usernametxt.Text.ToString();
                string passtxt = passwordtxt.Text.ToString();
                usernametxt.Text = "";
                passwordtxt.Text = "";
                _ = data.UserLogIn(emailtxt, passtxt);
                
            }
        }
    }
}