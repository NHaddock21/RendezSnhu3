using MvvmHelpers;
using RendezSnhu3.Model;
using RendezSnhu3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RendezSnhu3.Views
{
    [QueryProperty(nameof(EventId), nameof(EventId))]
    public partial class ViewEventPage : ContentPage
    {
        public string EventId { get; set; }
        public ObservableRangeCollection<Event> Events { get; set; }

        public ViewEventPage()
        {
            InitializeComponent();

            Events = new ObservableRangeCollection<Event>();

            BindingContext = this;


        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            int.TryParse(EventId, out var eventId);

            BindingContext = await EventService.ViewEvent(eventId);



        }

        private void RSVPButton(object sender, EventArgs e)
        {

        }
    }
}