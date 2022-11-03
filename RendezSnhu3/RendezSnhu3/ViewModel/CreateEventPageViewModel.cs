using RendezSnhu3.Model;
using RendezSnhu3.Services;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Command = MvvmHelpers.Commands.Command;

namespace RendezSnhu3.ViewModel
{
    public class CreateEventPageViewModel : INotifyPropertyChanged
    {
        public Event Event { get; } = new Event();
        public ICommand PostEvent { get; }

        public CreateEventPageViewModel()
        {
            PostEvent = new Command(AddEvent);
        }


        TimeSpan stime;
        public TimeSpan StartTime
        {
            get { return stime; }
            set { stime = value; OnPropertyChanged(nameof(StartTime)); }
        }
        TimeSpan etime;
        public TimeSpan EndTime
        {
            get { return etime; }
            set { etime = value; OnPropertyChanged(nameof(EndTime)); }
        }

        

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));



        public async void AddEvent()
        {
            DateTime startTime = new DateTime(StartTime.Ticks);
            DateTime endTime = new DateTime(EndTime.Ticks); 


            await EventService.AddEvent(Event.Name, Event.Location, Event.Category, Event.Date, startTime, endTime, Event.Max);
            Event.ClearFields();

        }





    }
}
