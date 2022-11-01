using RendezSnhu3.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RendezSnhu3.Services
{
    internal class Database
    {
        static SQLiteAsyncConnection data;

        static async Task Init()
        {
            if (data != null)
                return;
            
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            data = new SQLiteAsyncConnection(databasePath);

            await data.CreateTableAsync<Users>();
            
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
                userEmail = result[0].Email;
                userPass = result[0].Password;
            //userPass = db.QueryAsync<Users>("select password from users where email = ?", email).ToString();

            Console.WriteLine(userEmail);
            //Console.WriteLine(userPass);

            if (userEmail == null)
            {
                Console.WriteLine("Error");
                return;
            }
            else
            {
                if (userPass == pass)
                {
                    await Shell.Current.GoToAsync($"//HomePage");
                }
                else
                {
                    Console.WriteLine("Error password stupid");
                }
            }
        }

        public static async Task UserCreateAccount(string fname, string lname, string email, string password)
        {
            await Init();
            var user = new Users
            {
                FName = fname,
                LName = lname,
                Email = email,
                Password = password
            };

            await data.InsertAsync(user);
        }
    }
}
