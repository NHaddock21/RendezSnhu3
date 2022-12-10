using RendezSnhu3.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RendezSnhu3.Model
{
    class ViewEvent
    {
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string location;
        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        string image;
        public string Image
        {
            get { return image; }
            set { image = value; }
        }
        string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        string category;
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        DateTime startTime;

        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        DateTime endTime;
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        string fullTime;
        public string FullTime
        {
            get { return fullTime; }
            set { fullTime = startTime.ToString() +" - " + endTime.ToString(); }
        }

        string RSVPbuttonText;
        Database db = new Database();
        public string RSVPButtonText
        {
            get { return RSVPbuttonText; }
            set 
            {
                bool Rsvp = db.GetIfRSVP().Result;
                if (Rsvp)
                {
                    RSVPbuttonText = "UnRSVP";
                }
                else
                {
                    RSVPbuttonText = "RSVP";
                }
            }
        }
        string max;
        public string Max
        {
            get { return max; }
            set { max = value; }
        }

        string RSVPCount;
        public int count;
        public int Count
        {
            get { return count; }
            set 
            { 
                count = db.RSVPCount().Result; 
            }
        }
        int owner;
        public int Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        bool passed;
        public bool Passed
        {
            get { return passed ; }
            set { passed = value; }
        }
    }
}
