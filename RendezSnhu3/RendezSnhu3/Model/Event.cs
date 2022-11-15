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

        DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; OnPropertyChanged(nameof(Date)); }
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

   
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
            Max = string.Empty;
            Date = default;
            StartTime = default;
            EndTime = default;
                        
        }

    }
}
