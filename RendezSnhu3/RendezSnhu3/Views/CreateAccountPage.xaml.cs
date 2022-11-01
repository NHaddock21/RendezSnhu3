using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Xml.Linq;

namespace RendezSnhu3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccountPage : ContentPage
    {
        public CreateAccountPage()
        {
            InitializeComponent();
        }

        public bool ValidFirstName(string fname)
        {
            var firstname = fname;
            var firstnamePattern = new Regex("^[A-Z][a-zA-Z]*$");
            if (firstnamePattern.IsMatch(firstname))
            {
                return true;
            }
            else return false;
        }

        public bool ValidLastName(string lname)
        {
            var lastname = lname;
            var lastnamePattern = new Regex("^[A-Z][a-zA-Z]*$");
            if (lastnamePattern.IsMatch(lastname))
            {
                return true;
            }
            else return false;
        }

        public bool ValidEmail(string email)
        {
            if (email.Contains("@snhu.edu"))
            {
                return true;
            }
            else return false;
        }

        public bool ValidPassword(string p1)
        {
            var password = p1;
            var passwordPattern = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            if (passwordPattern.IsMatch(password))
            {
                return true;
            }
            else return false;
        
        }

        public bool PasswordMatch(string p1,string p2)
        {
            if (p1 == p2)
            {
                return true;
            }
            else return false;
        }

        private async void SubmitClicked(object sender, EventArgs e)
        {
            if (FirstNametxt.Text == null)
            {
                FirstNameError.Text = "Error First Name Required";
            }
            else if(!ValidFirstName(FirstNametxt.Text))
            {
                FirstNameError.Text = "Error Invalid First Name";
            }
            else
            {
                FirstNameError.Text = "";
            }
            if (LastNametxt.Text == null)
            {
                LastNameError.Text = "Error Last Name Required";
            }
            else if (!ValidLastName(LastNametxt.Text))
            {
                LastNameError.Text = "Error Invalid Last Name";
            }
            else
            {
                LastNameError.Text = "";
            }
            if (Emailtxt.Text == null)
            {
                EmailError.Text = "Error Email is Required";
            }
            else if (!ValidEmail(Emailtxt.Text))
            {
                EmailError.Text = "Error Email Must containt @snhu.edu";
            }
            else
            {
                EmailError.Text = "";
            }
            if (Passwordtxt.Text == null)
            {
                PasswordError.Text = "Error Password is Required";

            }
            else if (!ValidPassword(Passwordtxt.Text))
            {
                PasswordError.Text = "Password must contain: At least one lower case letter, At least one upper case letter, At least special character, At least one number and At least 8 characters length";
            }
            else
            {
                PasswordError.Text = "";
            }
            if (PasswordMatchtxt.Text == null)
            {
                PasswordMatchError.Text = "Password Confirmation Required";
            }
            else if (!PasswordMatch(Passwordtxt.Text,PasswordMatchtxt.Text))
            {
                PasswordMatchError.Text = "Error Passwords do not Match";
            }
            else
            {
                PasswordMatchError.Text = "";
            }
            if (FirstNametxt.Text != null && LastNametxt.Text != null && Emailtxt != null && Passwordtxt != null && PasswordMatchtxt != null && ValidFirstName(FirstNametxt.Text) == true && 
                ValidLastName(LastNametxt.Text) == true && ValidEmail(Emailtxt.Text) == true && ValidPassword(Passwordtxt.Text) == true && PasswordMatch(Passwordtxt.Text, PasswordMatchtxt.Text) == true)
            {
                await Shell.Current.GoToAsync($"//SignInPage");
                MessagingCenter.Send<CreateAccountPage>(this, "Hi");
            }
        }
        
    }
}