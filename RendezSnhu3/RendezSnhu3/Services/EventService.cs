using SQLite;
using RendezSnhu3.Model;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RendezSnhu3.Services
{
    public static class EventService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Event>();
        }

        public static async Task AddEvent(string name, string location, string category, DateTime date, DateTime sTime, DateTime eTime, string max)
        {
            await Init();
            var image = "";
           
                image = "https://www.freepnglogos.com/uploads/games-png/games-controller-game-icon-17.png";

            var events = new Event
            {
                Name = name,
                Location = location,
                Image = image,
                Date = date,
                StartTime = sTime,
                EndTime = eTime,
                Category = category,
                Max = max


            };

            var id = await db.InsertAsync(events);
        }

        public static async Task RemoveEvent(int id)
        {

            await Init();

            await db.DeleteAsync<Event>(id);
        }

        public static async Task<IEnumerable<Event>> GetEvent()
        {
            await Init();

            var events = await db.Table<Event>().ToListAsync();
            return events;
        }

        public static async Task<IEnumerable<Event>> SearchGetEvent(string searchTxt)
        {
            await Init();

            var events = await db.Table<Event>().Where(s => s.Name.Contains(searchTxt)).ToListAsync();
            return events;
        }

    }
}
