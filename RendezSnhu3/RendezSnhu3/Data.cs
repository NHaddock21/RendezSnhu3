using SQLite;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

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
        static SQLiteAsyncConnection db;

        static async Task Init()
        {
            if (db == null)
            {
                var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

                var db = new SQLiteAsyncConnection(databasePath);

                await db.CreateTableAsync<users>();
            }
        }

        public async Task UserLogIn(string email, string pass)
        {
            await Init();
            var userEmail = db.QueryAsync<users>("select email from users where email = ?", email).ToString();
            var userPass = db.QueryAsync<users>("select password from users where email = ?", email).ToString();

            if (userEmail == null)
            {
                return;
            }
            else
            {
                if (userPass == pass)
                {
                    Debug.Print("Next Page");
                }
            }
        }

        public static async Task UserCreateAccount(string fname, string lname, string email, string password)
        {
            await Init();
            var user = new users()
            {
                Fname = fname,
                Lname = lname,
                Email = email,
                Password = password
            };

            var id = await db.InsertAsync(user);
        }

        public static async Task ForgotPassword()
        {

        }
    }
}
