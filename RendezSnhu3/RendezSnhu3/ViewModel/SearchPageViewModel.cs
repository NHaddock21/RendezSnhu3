using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RendezSnhu3.ViewModel
{
    internal class SearchPageViewModel : INotifyPropertyChanged
    {
        string searchText;
        public string SearchText
        {
            get { return searchText; }
            set { searchText = value; OnPropertyChanged(nameof(SearchText)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
