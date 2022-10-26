using System;
using System.Collections;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient; // Import Statement for connecting C# to MySQL client
using Xamarin.Essentials;
using System.Diagnostics;
using Xamarin.Forms;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using SQLite;

namespace RendezSnhu3
{
    

    public class DatabaseConnection
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        string query;
        MySqlCommand cmd;
        MySqlDataReader reader;
        public string Connect()
        {
            string server = "localhost";
            string portnum = "3306";
            string database = "snhu";
            string username = "root";
            string password = "password";

            string connstring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            //string connstring = "SERVER=" + server + ";" + "PORT=" + portnum + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";" + "DATABASE=" + database + ";";

            return connstring;
        }

        public bool CheckIfUser(string email, string password)
        {  
            string connstring = Connect();

            query = "SELECT FROM users WHERE (email) Values(" + email + ")";

            conn = new MySql.Data.MySqlClient.MySqlConnection(connstring);

            cmd = new MySqlCommand(query, conn);  //MySqlCommand(query)
            //cmd.Parameters.AddWithValue("@email", email);

            cmd.Connection = conn;

            
            conn.Open();
        

            reader = cmd.ExecuteReader();
            
            if (reader == null)
            {
                conn.Close();
                return false;
            }
            else
            {
                string pass = reader["Password"].ToString();
                
                if (pass == password)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }

        }

        public void AddUser(string fname, string lname, string email, string password)
        {
            int setID; // Set new
            string connstring = Connect();
            query = "SELECT * FROM users ORDER BY userID DESC LIMIT 1";
            
            MySqlConnection conn = new MySqlConnection(connstring);
            
            cmd = new MySqlCommand(query, conn);

            reader = cmd.ExecuteReader();

            setID = int.Parse(reader["userID"].ToString()) + 1;

            query = "INSERT INTO users(userID, fName, lName, email, password) VALUES (@fName, @lName, @phone, @state)";

            cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@userID", setID);
            cmd.Parameters.AddWithValue("@fName", fname);
            cmd.Parameters.AddWithValue("@lName", lname);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);

            cmd = new MySqlCommand(query);  //MySqlCommand(query)
            //cmd.Parameters.AddWithValue("@email", email);

            cmd.Connection = conn;


        }

        public void ResetPassword(string email)
        {
            string connstring = Connect();

            query = "SELECT FROM users WHERE (email) Values(" + email + ")";

            MySqlConnection conn = new MySqlConnection(connstring);

            cmd = new MySqlCommand(query);  //MySqlCommand(query)
            //cmd.Parameters.AddWithValue("@email", email);

            cmd.Connection = conn;


            conn.Open();


            reader = cmd.ExecuteReader();

            if (reader == null)
            {
                conn.Close();
            }
            else
            {
                string userID = reader["userID"].ToString();

                string newPassword = "";
                string charactersForPass = ("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%*?");
                for (int loopChars = 0; loopChars < 6; loopChars++)
                {
                    Random rand = new Random();
                    newPassword += charactersForPass[rand.Next(charactersForPass.Length)];
                }

                query = "REPLACE INTO users SET userID = @userID password = @password";
                cmd = new MySqlCommand(query, conn);

            }

        }
    }

}

    
