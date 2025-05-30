﻿using MvvmHelpers;
using MvvmHelpers.Commands;
using RendezSnhu3.Model;
using RendezSnhu3.Services;
using RendezSnhu3.Views;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace RendezSnhu3.ViewModel
{
    public class HomePageViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Event> Event { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Event> RemoveCommand { get; }
        public AsyncCommand<Event> SelectedCommand { get; }


        public HomePageViewModel()
        {
            Event = new ObservableRangeCollection<Event>();

            RefreshCommand = new AsyncCommand(Refresh);          
            RemoveCommand = new AsyncCommand<Event>(Remove);
            SelectedCommand = new AsyncCommand<Event>(Selected);


            Task.Run(async () => await Refresh());
        }
        async Task Remove(Event events)
        {
            await EventService.RemoveEvent(events.Id);
            await Refresh();
        }

        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            Event.Clear();

            var events = await EventService.GetEvent();

            Event.AddRange(events);

            IsBusy = false;
        }
        async Task Selected(Event events){
            
            
            
            await Shell.Current.GoToAsync($"{nameof(ViewEventPage)}?EventId={events.Id}");
        }

    }

}
