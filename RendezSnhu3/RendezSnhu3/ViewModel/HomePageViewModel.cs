using MvvmHelpers;
using MvvmHelpers.Commands;
using RendezSnhu3.Model;
using RendezSnhu3.Services;
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
        //public AsyncCommand AddCommand { get; }
        public AsyncCommand<Event> RemoveCommand { get; }


        public HomePageViewModel()
        {
            Event = new ObservableRangeCollection<Event>();


            RefreshCommand = new AsyncCommand(Refresh);
            //AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Event>(Remove);
        }
/*
        async Task Add()
        {
            /var name = await App.Current.MainPage.DisplayPromptAsync("Name", "Name of event");
            if (name == null) return;
            var category = await App.Current.MainPage.DisplayPromptAsync("Category", "Category of event");
            await EventService.AddEvent(name, category);
            await Refresh();
        }
*/
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


    }

}
