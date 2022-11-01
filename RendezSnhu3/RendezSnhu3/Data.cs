using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Linq.Expressions;
using System.Collections;
using static SQLite.SQLite3;
using System.Linq;

namespace RendezSnhu3
{

    public class users
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class Data
    {
        //SQLiteConnection connect;
        static SQLiteAsyncConnection db;

        static string dataFile = "RendezSnhu.db";
        static async Task Init()
        {
            //Checks if db is already assigned
            if (db != null)
                return;
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dataFile);
            db = new SQLiteAsyncConnection(databasePath);
            await db.CreateTableAsync<users>();
            //SQLiteConnection connect = new SQLiteConnection(databasePath);
        }

        public async Task UserLogIn(string email, string pass)
        {
            string userEmail = null;
            string userPass = "password123";
            await Init();
            //string userEmail = db.Query<Valuation>("select email from users where email = ?", email).ToString();
            var query = db.Table<users>().Where(v => v.Email.Equals(email));
            Console.WriteLine(query);
            var executeQuery = await query.ToListAsync();
            
            userEmail = executeQuery.ToString();

            Console.WriteLine($" pulled from data email {userEmail}");

            //string userPass = db.QueryAsync<users>("select password from users where email = ?", email).ToString();
            //Console.WriteLine($" pulled from data pass {userPass}");
            await Task.Delay(2000);
            if (userEmail == null)
            {
                Debug.Print("Error no account");
                return;
            }
            else
            {
                if (userPass == pass)
                {
                    Debug.Print("Next Page");
                    await Shell.Current.GoToAsync($"//HomePage");
                }
                else
                {
                    Debug.Print("Error no account");
                }
            }
        }

        public static async Task UserCreateAccount(string fName, string lName, string email, string password)
        {
            await Init();
            //var userEmail = db.Table<users>().Where(v => v.Email.Equals(email));
            //if (userEmail == null)
            //{
                var users = new users()
                {
                    Fname = fName,
                    Lname = lName,
                    Email = email,
                    Password = password
                };
                await db.InsertAsync(users);
             
            //}
        }

        public static async Task ForgotPassword(string email)
        {
            await Init();

            var password = db.QueryAsync<users>("select password from users where email = ?", email).ToString();
        }
    }
}
