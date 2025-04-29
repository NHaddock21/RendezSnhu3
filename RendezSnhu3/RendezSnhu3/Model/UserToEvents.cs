using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RendezSnhu3.Model
{
    public class UserToEvents : INotifyPropertyChanged
    {

        int userID;
        public int UserID
        {
            get { return userID; }
            set { userID = value; OnPropertyChanged(nameof(UserID)); }
        }
        int eventID;
        public int EventID
        {
            get { return eventID; }
            set { eventID = value; OnPropertyChanged(nameof(EventID)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name) =>
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
