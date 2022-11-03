using MvvmHelpers;
using MvvmHelpers.Commands;
using MySql.Data.MySqlClient;
using RendezSnhu3.Model;
using RendezSnhu3.Services;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;
using Command = MvvmHelpers.Commands.Command;

namespace RendezSnhu3.ViewModel
{
    public class CreateEventPageViewModel : INotifyPropertyChanged
    {
        public Category Category { get; } = new Category();
        public Event Event { get; } = new Event();
        public CreateEventPageViewModel()
        {
            PostEvent = new Command(AddEvent);
        }

        public ICommand PostEvent { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public async void AddEvent()
        {
            await EventService.AddEvent(Event.Name, Event.Location, Event.Date, Event.StartTime, Event.EndTime, Event.Max);
            Event.ClearFields();
        }





    }
}
