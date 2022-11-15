using MvvmHelpers;
using MvvmHelpers.Commands;
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
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }
        public ObservableRangeCollection<Event> Event { get; set; }
        public AsyncCommand RefreshCommand { get; }

        async void OnTextChanged(object sender, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            var events = await EventService.SearchGetEvent(searchBar.Text);
            Event.AddRange(events);
        }
    }
}