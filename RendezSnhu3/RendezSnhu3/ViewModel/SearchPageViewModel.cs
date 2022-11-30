using MvvmHelpers;
using MvvmHelpers.Commands;
using RendezSnhu3.Model;
using RendezSnhu3.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RendezSnhu3.ViewModel
{
    internal class SearchPageViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Event> Events { get; set; }

        public SearchPageViewModel()
        {

            Events = new ObservableRangeCollection<Event>();

 
        }

        async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchTerm = e.NewTextValue;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = string.Empty;
            }

            searchTerm = searchTerm.ToLowerInvariant();

            var filteredEvents = await EventService.SearchGetEvent(searchTerm);

            foreach (var value in Events)
            {

                if (!filteredEvents.Contains(value))
                {
                    Events.Remove(value);
                }
                else if (!Events.Contains(value))
                {
                    Events.Add(value);
                }
            }
        }
    }
}
