using MvvmHelpers;
using RendezSnhu3.Model;
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
    public partial class ShowEventPage : ContentPage
    {
        public int id;
        public string name;
        public string location;
        public string image;
        public string category;
        public DateTime date;
        public DateTime startTime;
        public DateTime endTime;
        public string max;
        public int owner;
        public bool passed;

        public ShowEventPage()
        {

            InitializeComponent();

        }
        private async void RSVPButton(object sender, EventArgs e)
        {

        }
    }
}