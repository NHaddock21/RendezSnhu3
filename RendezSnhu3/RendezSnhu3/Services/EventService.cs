﻿using SQLite;
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

        public static async Task AddEvent(string name, string location, string description, string category, DateTime date, DateTime sTime, DateTime eTime, string max)
        {
            await Init();
            Database database= new Database();
            var image = "";

            if (category == "Gaming")
            {
                image = "https://www.freepnglogos.com/uploads/games-png/games-controller-game-icon-17.png";
            }
            else if (category == "Sports")
            {
                image = "https://www.clipartqueen.com/image-files/soccer-ball-clipart.png";
            }
            else if (category == "Leisure")
            {
                image = "https://i.pinimg.com/originals/cd/49/2b/cd492bad710672736c6349d50911eadc.png";
            }
            else if (category == "Business")
            {
                image = "https://www.nicepng.com/png/detail/21-218731_handshake-vector-png-clipart-black-and-white-library.png";
            }
            else if (category == "Music")
            {
                image = "https://static.thenounproject.com/png/1247867-200.png";
            }
            else if (category == "Art")
            {
                image = "https://cdn-icons-png.flaticon.com/512/103/103461.png";
            }
            else if (category == "Nature")
            {
                image = "https://cdn-icons-png.flaticon.com/512/1561/1561127.png";
            }


            var events = new Event
            {
                Name = name,
                Location = location,
                Image = image,
                Description = description,
                Date = date,
                StartTime = sTime,
                EndTime = eTime,
                Category = category,
                Max = max,
                Owner = database.getUserID(),
                Passed = false
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

            var events = await db.Table<Event>().Where(s => s.Passed == false).ToListAsync();
            
            if (events.Count > 1) {
                for (int i = 0; i < events.Count; i++)
                {
                    for (int j = 0; j < events.Count - 1; j++)
                    {
                        if (events[j].Date < DateTime.Now)
                        {
                            events[j].Passed = true;
                            await db.InsertOrReplaceAsync(events[j]);
                            events.RemoveAt(j);
                        }
                        else if (events[j].Date == DateTime.Now)
                        {
                            if (events[j].StartTime < DateTime.Now)
                            {
                                events[j].Passed = true;
                                await db.InsertOrReplaceAsync(events[j]);
                                events.RemoveAt(j);
                            }
                            else
                            {
                                if (events[j].StartTime > events[j + 1].StartTime)
                                {
                                    (events[j], events[j + 1]) = (events[j + 1], events[j]);
                                }
                            }
                        }
                        else
                        {
                            if (events[j].Date > events[j + 1].Date)
                            {
                                (events[j], events[j + 1]) = (events[j + 1], events[j]);
                            }
                            else if (events[j].Date == events[j+1].Date) 
                            {
                                if (events[j].StartTime > events[j + 1].StartTime)
                                {
                                    (events[j], events[j + 1]) = (events[j + 1], events[j]);
                                }
                            }
                        }
                    }
                }
            }
            return events;
        }

        public static async Task<IEnumerable<Event>> SearchGetEvent(string searchTxt)
        {
            await Init();

            searchTxt = searchTxt.ToLower();
            
            

            var events = await db.Table<Event>().Where(s => s.Name.ToLower().Contains(searchTxt) || s.Category.ToLower().Contains(searchTxt)).ToListAsync();

            return events;
        }
        public static async Task<Event> ViewEvent(int id)
        {
            await Init();

            
            var events = await db.Table<Event>().FirstOrDefaultAsync(s => s.Id == id);

            return events;
                    
        }

    }
}
