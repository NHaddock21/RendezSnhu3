using MvvmHelpers;
using RendezSnhu3.Model;
using RendezSnhu3.Services;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RendezSnhu3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {


        public ObservableRangeCollection<Event> Events { get; set; }

        public SearchPage()
        {
            InitializeComponent();

            

            Events = new ObservableRangeCollection<Event>();


            BindingContext = this;

        }

        public async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchTerm = e.NewTextValue;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = string.Empty;
            }

            //searchTerm = searchTerm.ToLowerInvariant();

           

            var filteredEvents = await EventService.SearchGetEvent(searchTerm);

            int count = Events.Count;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Events.Clear();
            }
            else
            {
                
                Events.AddRange(filteredEvents);
                    
                
            }
            /*
            foreach (var value in Events)
            {
                
                if (!filteredEvents.Contains(value))
                {
                    Events.RemoveRange((System.Collections.Generic.IEnumerable<Event>)value);
                }
                else if (!events.Contains(value))
                {
                    Events.AddRange((System.Collections.Generic.IEnumerable<Event>)value);
                }

            }
            */
        }
    }
}