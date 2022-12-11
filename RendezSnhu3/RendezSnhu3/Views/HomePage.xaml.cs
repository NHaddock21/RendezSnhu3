using RendezSnhu3.Model;
using RendezSnhu3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RendezSnhu3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        static string ID;
        public HomePage()
        {
            InitializeComponent();
        }
        Database db = new Database();
        Event e = new Event();  
        private async void EventSelected(object sender, ItemTappedEventArgs e)
        {
            ListView eventClicked = sender as ListView;
            var device = e.Item as Event;
            db.SetEventID(device.Id.ToString());
            db.SetEvent(device.Id, device.Name, device.Location, device.Image, device.Description, device.Category, device.Date, device.StartTime, device.EndTime, device.Max, device.Owner, device.Passed);
            await Shell.Current.GoToAsync($"//HomePage/ShowEventPage");
        }

    }
}