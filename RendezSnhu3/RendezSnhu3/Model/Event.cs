using MvvmHelpers;
using RendezSnhu3.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

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
        string description;
        public string Description
        {
            get { return description; }
            set { description= value; OnPropertyChanged(nameof(Description));}
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

        int owner;
        public int Owner
        {
            get { return owner; }
            set { owner= value; OnPropertyChanged(nameof(Owner));}
        }
        bool passed;
        public bool Passed { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;


        void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public void ClearFields()
        {

            Name = string.Empty;
            Location = string.Empty;
            Description = string.Empty;
            Image = string.Empty;
            Category = string.Empty;
            Max = string.Empty;

            Date = default;
            StartTime = default;
            EndTime = default;

        }

    }
}
