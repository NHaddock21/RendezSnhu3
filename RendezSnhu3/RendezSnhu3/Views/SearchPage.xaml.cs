using MvvmHelpers;
using MvvmHelpers.Commands;
using RendezSnhu3.Model;
using RendezSnhu3.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RendezSnhu3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {



        public ObservableRangeCollection<Event> Events { get; set; }

        public AsyncCommand<Event> SelectedCommand { get; }

        public SearchPage()
        {
            InitializeComponent();

            Events = new ObservableRangeCollection<Event>();

            SelectedCommand = new AsyncCommand<Event>(Selected);

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

            Events.Clear();

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

           
        }
        async Task Selected(Event events)
        {


            //$"{nameof(ViewEventPage)}?EventId={events.Id}";


            await Shell.Current.GoToAsync($"{nameof(ViewEventPage)}?EventId={events.Id}");
        }

    }
}