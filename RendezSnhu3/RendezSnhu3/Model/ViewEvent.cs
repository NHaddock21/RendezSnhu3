using RendezSnhu3.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RendezSnhu3.Model
{
    class ViewEvent
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
       
       
        public string Image{get; set;}
       
        public string Description { get; set; }
       
        public string Category { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string FullTime { get; set; }
        public void SetFullTime(DateTime start, DateTime end)
        {
            FullTime = start.ToString() + " - " + end.ToString();
        }
        public string RSVPButtonText { get; set; }
        Database db = new Database();
        public void SetRSVPText()
        {
            var RSVP = db.GetIfRSVP();
            if (RSVP.Result)
            {
                RSVPButtonText = "UnRSVP";
            }
            else
            {
                RSVPButtonText = "RSVP";
            }
        }
        public string Max
        {
            get; set;
        }

        public string RSVPCount { get; set; }

        public void CountRSVP()
        {
            Task<int> count = db.RSVPCount();
            RSVPCount= count.ToString();
        }
        public int Owner
        {
            get; set;
        }
        public bool Passed
        {
            get; set;
        }
    }
}
