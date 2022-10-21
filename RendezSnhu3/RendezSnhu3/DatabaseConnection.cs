using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace RendezSnhu3
{
    class DatabaseConnection
    {
        static void Connect()
        {
            string server = "localhost"; // If not using a cloud database, use localhost. If using cloud database, use the IP to the server
            string database = "snhu"; // Whatever database you want use for the application
            string username = "root"; // The username of your MySQL client
            string password = "password"; // The password of your MySQL client

            // Throw all the variables into this connection string
            // MUST USE THIS FORMAT! (server, database, username, then password)
            string connstring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";

        }
    }
}
