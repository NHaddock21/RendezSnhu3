using RendezSnhu3.Model;
using RendezSnhu3.ViewModel;
using RendezSnhu3.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RendezSnhu3.Services
{
    internal class Database
    {
        static SQLiteAsyncConnection data;
        int userID;
        static async Task Init()
        {

            //Checks if data location already assigned
            if (data != null)
                return;

            //Assigns if not
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            data = new SQLiteAsyncConnection(databasePath);

            await data.CreateTableAsync<Users>();
            await data.CreateTableAsync<UserSettings>();
            await data.CreateTableAsync<UserToEvents>();

        }

        public async Task UserLogIn(string email, string pass)
        {
            await Init();
            string userEmail = null;
            string userPass = null;
            //var query = data.QueryAsync<Users>("select email from users where email = ?", email);

            var query = data.Table<Users>().Where(s => s.Email.Equals(email));

            var result = await query.ToListAsync();

            if (result.Count != 0)
            {
                userEmail = result[0].Email;
                userPass = result[0].Password;
            }
            //userPass = db.QueryAsync<Users>("select password from users where email = ?", email).ToString();

            Console.WriteLine(userEmail);
            //Console.WriteLine(userPass);

            if (userEmail == null)
            {
                MessagingCenter.Send<Database>(this, "Error");
                return;
            }
            else
            {
                if (userPass == pass)
                {
                    List<string> emailList = new List<string>();
                    emailList.Add(userEmail);
                    SendEmail se = new SendEmail();
                    se.Email(email);
                    await Shell.Current.GoToAsync($"//HomePage");
                }
                else
                {
                    MessagingCenter.Send<Database>(this, "Error");
                    
                }
            }
        }

        public async Task UserCreateAccount(string fname, string lname, string email, string password)
        {
            await Init();
            var user = new Users
            {
                FName = fname,
                LName = lname,
                Email = email,
                Password = password
            };
            SendEmail se = new SendEmail();
            se.Email(email); 
            await data.InsertAsync(user);
        }

        public static async Task ForgotPassword(string email)
        {
            await Init();
        }
        

        public async Task<List<UserToEvents>> GetIfRSVP (int eventID)
        {
            await Init(); 
            var query = data.Table<UserToEvents>().Where(s => s.EventID.Equals(eventID)).Where( m => m.UserID.Equals(userID));
            var result = await query.ToListAsync();
            return result;
        }

        public async Task SetRSVP(int eventID)
        {
            await Init();
            var RSVP = new UserToEvents
            {
                UserID = userID,
                EventID = eventID,
            };
            await data.InsertAsync(RSVP);
        }

        public async Task UnRSVP(int eventID)
        {
            await Init();
            var RSVP = new UserToEvents
            {
                UserID = userID,
                EventID = eventID,
            };
            await data.DeleteAsync(RSVP);
        }


    }
}

//Get Each part of an event
// var query = data.Table<Event>().Where(s => s.ID.Equals(ID));
