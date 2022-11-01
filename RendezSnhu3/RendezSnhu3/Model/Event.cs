using MvvmHelpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RendezSnhu3.Model
{
    public class Event : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }
        string location;
        public string Location
        {
            get { return location; }
            set { location = value; OnPropertyChanged(nameof(Location)); }
        }
        string image;
        public string Image
        {
            get { return image; }
            set { image = value; OnPropertyChanged(nameof(Image)); }
        }
        string category;
        public string Category
        {
            get => category; set { category = value; OnPropertyChanged(nameof(Category)); }
        }
        string date;
        public string Date
        {
            get { return date; }
            set { date = value; OnPropertyChanged(nameof(Date)); }
        }
        string sTime;
        public string StartTime
        {
            get { return sTime; }
            set { sTime = value; OnPropertyChanged(nameof(StartTime)); }
        }
        string eTime;
        public string EndTime
        {
            get { return eTime; }
            set { eTime = value; OnPropertyChanged(nameof(EndTime)); }
        }
        string max;
        public string Max
        {
            get { return max; }
            set { max = value; OnPropertyChanged(nameof(Max)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


        public void SetProperty(string prop, string val)
        {

        }

        public void ClearFields()
        {
            Name = string.Empty;
            Location = string.Empty;
            Image = string.Empty;
            Category = string.Empty;
            Date = string.Empty;
            StartTime = string.Empty;
            EndTime = string.Empty;
            Max = string.Empty;
            
        }

    }
}
