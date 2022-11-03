using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RendezSnhu3.Model
{
    internal class UserSettings : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int AccountID { get; set; }

        string description;
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(nameof(Description));  }
        }

        string profile_pic;
        public string ProfilePicture
        {
            get { return profile_pic; }
            set { profile_pic = value; OnPropertyChanged(nameof(ProfilePicture)); }
        }

        int userID;
        public int UserID
        {
            get { return userID; }
            set { userID = value; OnPropertyChanged(nameof(UserID)); }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
