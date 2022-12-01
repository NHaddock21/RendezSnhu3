using RendezSnhu3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RendezSnhu3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void ItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//HomePage/ShowEventPage");
        }



    }
}