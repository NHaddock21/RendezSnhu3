using MvvmHelpers;
using RendezSnhu3.Model;
using RendezSnhu3.Services;
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
        Database db = new Database();
        public ShowEventPage()
        {

            InitializeComponent();
            EventTitle.Text = db.GeteventName();
            EventImage.Source = db.GeteventImage();
            EventDate.Text = db.GeteventDate();
            EventTime.Text = db.GetFullTime();
            EventDescription.Text = db.GeteventDescription();
            bool RSVPText = db.GetIfRSVP().Result;
            if (RSVPText)
            {
                RSVPbut.Text = "UnRSVP";
            }
            else
            {
                RSVPbut.Text = "RSVP";
            }
            NumRSVP.Text = db.GetRSVPCount();
            MaxRSVP.Text = db.GetEventMax();
        }
        private async void RSVPButton(object sender, EventArgs e)
        {

        }
    }
}