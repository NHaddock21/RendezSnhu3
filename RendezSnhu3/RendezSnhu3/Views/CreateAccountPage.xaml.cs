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
    public partial class CreateAccountPage : ContentPage
    {
        readonly int passwordLimit = 8;
        readonly Data data = new Data();
        public CreateAccountPage()
        {
            InitializeComponent();
        }

        private void CreateAccountClick(object sender, EventArgs e)
        {
            // Check if entries null 
            if (fNametxt.Text != null & lNametxt.Text != null & emailtxt.Text != null & passwordtxt.Text != null & confPasswordtxt.Text != null)
            {
                // Get Entries
                string fName = fNametxt.Text.ToString();
                string lName = lNametxt.Text.ToString();
                string email = emailtxt.Text.ToString();
                string password = passwordtxt.Text.ToString();
                string confPassword = confPasswordtxt.Text.ToString();

                fNametxt.Text = "";
                lNametxt.Text = "";
                emailtxt.Text = "";
                passwordtxt.Text = "";
                confPasswordtxt.Text = "";


                //Check if meets password length
                if (password.Length >= passwordLimit)
                {
                    //
                    if (password == confPassword)
                    {
                        _ = Data.UserCreateAccount(fName, lName, email, password);
                    }
                }
                
            }
        }
            
    }
}